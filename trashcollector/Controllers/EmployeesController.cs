using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using trashcollector.Data;
using trashcollector.Models;

namespace trashcollector.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public IActionResult Index()
        {
            var viewModel = new EmployeeViewModel();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var employee = _context.Employees.FirstOrDefault(e => e.UserId == userId);
            if (employee is null)
            {
                return RedirectToAction(nameof(Create));
            }
            var customers = _context.Customers.Select(c => c);
            var areaCustomers = customers.Where(c => c.Address.zipCode == employee.ZipCode).ToList();
            //viewModel.Customers = customer;
            viewModel.Address = _context.Addresses.FirstOrDefault(a => a.Id == viewModel.Customer.AddressId);
            viewModel.Account = _context.Accounts.FirstOrDefault(a => a.Id == viewModel.Customer.AccountId);

            return RedirectToAction(nameof(Edit));
        }

        //// GET: Employees/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var employee = await _context.Employees
        //        .Include(e => e.IdentityUser)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(employee);
        //}

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var employee = viewModel.Employee;
                employee.UserId = userId;
                _context.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Edit));
            }            
            return View(viewModel);
        }

        // GET: Employees/Edit/5
        public IActionResult Edit()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return NotFound();
            }            
            var employee = _context.Employees.FirstOrDefault(e => e.UserId == userId);
            if (employee == null)
            {
                return NotFound();
            }
            var viewModel = new EmployeeViewModel();
            
            var customers = _context.Customers.Where(c => c.Address.zipCode == employee.ZipCode).Include(c => c.Address).ToList();
            //var account = _context.Accounts.Include(a => a.LastPickupDate).FirstOrDefault(a => a.Id == viewModel.Account.Id);
            //viewModel.Account.LastPickupDate = account;
            viewModel.Employee = employee;
            viewModel.Customers = customers;
            
            return View(viewModel);
        }
        public IActionResult ConfirmPickup(int? id)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.Id == id);
            account.Balance += 10;
            account.LastPickupDate = DateTime.Today;
            _context.Accounts.Update(account);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,ZipCode,UserId")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", employee.UserId);
            return View(employee);
        }
        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}

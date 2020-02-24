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
            //var viewModel = new EmployeeViewModel();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var employee = _context.Employees.FirstOrDefault(e => e.UserId == userId);
            if (employee is null)
            {
                return RedirectToAction(nameof(Create));
            }
          
            return RedirectToAction(nameof(Edit));
        }
        public IActionResult Filter()
        {
            var viewModel = new EmployeeViewModel();
            var customers = _context.Customers
                                .Include(c => c.Address)
                                .Include(c => c.Account)
                                .ToList();
            viewModel.Customers = customers;
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Filter(EmployeeViewModel viewModel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.FirstOrDefault(e => e.UserId == userId);
            return View(viewModel);
        }
        //public List<Customer> FilterTodayCustomers(EmployeeViewModel employee)
        //{
        //    var customers = _context.Customers.Where(c => c.Address.zipCode == employee.Employee.ZipCode).ToList();
        //    var filteredCustomers = new List<Customer>(); 
        //    foreach (var customer in customers)
        //    {
        //        var account = _context.Accounts.FirstOrDefault(a => a.Id == customer.AccountId);
        //        if (!account.IsSuspended && DateTime.Today.DayOfWeek == account.PickupDay)
        //        {
        //            filteredCustomers.Add(customer);
        //        }
        //        else if (DateTime.Today == account.OneTimePickup)
        //        {
        //            filteredCustomers.Add(customer);
        //        }
        //    }
        //    return filteredCustomers;
        //}

         // GET: Employees/Details
        public IActionResult Details(int? id)
        {
            var viewModel = new EmployeeViewModel();
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            viewModel.Address = _context.Addresses.FirstOrDefault(a => a.Id == customer.AddressId);
            viewModel.Customer = customer;
            return View(viewModel);      
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create        
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
                return RedirectToAction(nameof(Index));
            }            
            return RedirectToAction(nameof(Index));
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

            var customers = _context.Customers
                                .Include(c => c.Address)
                                .Include(c => c.Account)
                                .ToList();

            customers = customers.Where(c => c.Address.zipCode == employee.ZipCode && 
                                    c.Account.IsSuspended == false &&
                                    (c.Account.PickupDay == DateTime.Today.DayOfWeek ||
                                     c.Account.OneTimePickup == DateTime.Today)).ToList();
                                       
            viewModel.Employee = employee;
            viewModel.Customers = customers;            
            
            return View(viewModel);
        }
        public IActionResult ConfirmPickup(int? id)
        {
            var customer = _context.Customers.FirstOrDefault(c=> c.Id == id);
            var account = _context.Accounts.FirstOrDefault(a => a.Id == customer.AccountId);
            account.Balance += 10;
            account.LastPickupDate = DateTime.Today;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: Employees/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeViewModel employee)
        {
            return RedirectToAction(nameof(Index));
        }
        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}

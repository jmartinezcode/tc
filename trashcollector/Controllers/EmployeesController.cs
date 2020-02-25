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
            viewModel.Employee = employee;
            var customers = _context.Customers
                                .Include(c => c.Address)
                                .Include(c => c.Account)
                                .ToList();

            customers = customers.Where(c => c.Address.zipCode == employee.ZipCode &&
                                    c.Account.IsSuspended == false &&
                                    (c.Account.PickupDay == DateTime.Today.DayOfWeek ||
                                     c.Account.OneTimePickup == DateTime.Today)).ToList();
            viewModel.Day = DateTime.Today.DayOfWeek;            
            viewModel.Customers = customers;
            return View(viewModel);
        }
        public IActionResult Filter()
        {
            var viewModel = new EmployeeViewModel();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var employee = _context.Employees.FirstOrDefault(e => e.UserId == userId);
            var customers = _context.Customers
                                .Include(c => c.Address)
                                .Include(c => c.Account)
                                .ToList();
            viewModel.Employee = employee;
            viewModel.Customers = customers;
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Filter(EmployeeViewModel viewModel)
        {
            var newViewModel = new EmployeeViewModel();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.FirstOrDefault(e => e.UserId == userId);
            var customers = _context.Customers
                                .Include(c => c.Address)
                                .Include(c => c.Account)
                                .ToList();
            customers = customers.Where(c => c.Address.zipCode == employee.ZipCode &&
                                                    c.Account.IsSuspended == false &&
                                                    c.Account.PickupDay == viewModel.Day).ToList();
            
            newViewModel.Customers = customers;
            newViewModel.Employee = employee;
            newViewModel.Day = viewModel.Day;
            if (newViewModel.Day == DateTime.Today.DayOfWeek)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(newViewModel);
        }
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
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var newEmployee = new Employee();
                newEmployee.UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                newEmployee.FirstName = employee.FirstName;
                newEmployee.LastName = employee.LastName;
                newEmployee.ZipCode = employee.ZipCode;
                _context.Add(newEmployee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }            
            return RedirectToAction(nameof(Index));
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

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}

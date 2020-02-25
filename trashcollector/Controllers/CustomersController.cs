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
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new CustomerAddressAccountViewModel();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var customer = _context.Customers.FirstOrDefault(c => c.UserId == userId);
            if (customer is null)
            {
                return RedirectToAction(nameof(Create));
            }
            viewModel.Customer = customer;
            viewModel.Address = _context.Addresses.FirstOrDefault(a => a.Id == viewModel.Customer.AddressId);
            viewModel.Account = _context.Accounts.FirstOrDefault(a => a.Id == viewModel.Customer.AccountId);
            
            return RedirectToAction(nameof(Edit));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerAddressAccountViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var customer= viewModel.Customer;
                var address = viewModel.Address;
                var account = viewModel.Account;

                _context.Addresses.Add(address);
                _context.Accounts.Add(account);
                _context.SaveChanges();

                customer.AddressId = _context.Addresses.FirstOrDefault(a => a.Equals(address)).Id;
                customer.UserId = userId;
                customer.AccountId = _context.Accounts.FirstOrDefault(a => a.Equals(account)).Id;

                
                
                _context.Customers.Add(customer);

                _context.SaveChanges();
                return RedirectToAction(nameof(Edit));
            }
            return View(viewModel);
        }
        public IActionResult Edit()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return NotFound();
            }

            var customer = _context.Customers.FirstOrDefault(a => a.UserId == userId);
            if (customer == null)
            {
                return NotFound();
            }
            var viewModel = new CustomerAddressAccountViewModel();
            viewModel.Customer = customer;
            viewModel.Address = _context.Addresses.FirstOrDefault(a => a.Id == viewModel.Customer.AddressId);
            viewModel.Account = _context.Accounts.FirstOrDefault(a => a.Id == viewModel.Customer.AccountId);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerAddressAccountViewModel viewModel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return NotFound();
            }
            var customerFromDb = _context.Customers.FirstOrDefault(a => a.UserId == userId);
            if (customerFromDb == null)
            {
                return NotFound();
            }
            //customerFromDb = viewModel.Customer;
            var accountFromDb = _context.Accounts.FirstOrDefault(a => a.Id == customerFromDb.AccountId);
            accountFromDb.PickupDay = viewModel.Account.PickupDay;
            accountFromDb.OneTimePickup = viewModel.Account.OneTimePickup;
            accountFromDb.IsSuspended = SetIsSuspended(viewModel);
            if (viewModel.Account.StartSuspension < accountFromDb.LastPickupDate)
            {
                viewModel.Account.StartSuspension = accountFromDb.LastPickupDate;
            }
            accountFromDb.StartSuspension = viewModel.Account.StartSuspension;
            if (viewModel.Account.EndSuspension < accountFromDb.StartSuspension)
            {
                viewModel.Account.EndSuspension = accountFromDb.StartSuspension;
            }
            accountFromDb.EndSuspension = viewModel.Account.EndSuspension;
            _context.Accounts.Update(accountFromDb);
            _context.SaveChanges();
            return RedirectToAction(nameof(Edit));
        }
        private bool SetIsSuspended(CustomerAddressAccountViewModel viewModel)
        {
            if (DateTime.Today >= viewModel.Account.StartSuspension && DateTime.Today <= viewModel.Account.EndSuspension)
            {
                return true;
            }
            return false;
        }
    }
}

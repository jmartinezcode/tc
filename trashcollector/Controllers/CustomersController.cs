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
            
            var customer = _context.Customers
                .FirstOrDefault(m => m.UserId == userId);
            if (customer is null)
            {
                return RedirectToAction(nameof(Create));
            }
            viewModel.Customer = customer;
            viewModel.Address = _context.Addresses.FirstOrDefault(a => a.Id == viewModel.Customer.AddressId);
            viewModel.Account = _context.Accounts.FirstOrDefault(a => a.Id == viewModel.Customer.AccountId);
            
            return View(viewModel);
        }
        public IActionResult Create()
        {
            if (User.IsInRole("Customer"))
            {
                var viewModel = new CustomerAddressAccountViewModel { Customer = new Customer(), Address = new Address(), Account = new Account() };
                return View(viewModel);
            }
            return RedirectToAction(nameof(Create));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerAddressAccountViewModel customerAddressAccountViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerAddressAccountViewModel);
                _context.SaveChanges();
                return RedirectToAction(nameof(Create));
            }
            return View(customerAddressAccountViewModel);
        }


        //public async Task<IActionResult> Index()
        //{
        //    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    if(userId is null)
        //    {
        //        return RedirectToAction(nameof(Create));
        //    }
        //    var viewModel = new CustomerAddressAccountViewModel();
        //    viewModel.Customer = _context.Customers.FirstOrDefault(c => c.UserId == userId);
        //    viewModel.Address = _context.Addresses.FirstOrDefault(a => a.Id == viewModel.Customer.Id);
        //    viewModel.Account = _context.Accounts.FirstOrDefault(a => a.Id == viewModel.Customer.Id);

        //    return View(viewModel);
        //}

        //// GET: Customers1/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var customer = await _context.Customers
        //        .Include(c => c.Address)
        //        .Include(c => c.IdentityUser)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(customer);
        //}

        //// GET: Customers1/Create
        //public IActionResult Create()
        //{
        //    if (User.IsInRole("Customer") && User.Identity.IsAuthenticated)
        //    {
        //        var viewModel = new CustomerAddressAccountViewModel { Customer = new Customer(), Address = new Address(), Account = new Account() };
        //        return View(viewModel);
        //    }
        //    return RedirectToAction(nameof(Create));
        //}

        //// POST: Customers1/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(CustomerAddressAccountViewModel customerAddressAccountViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(customerAddressAccountViewModel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Create));
        //    }                   
        //    return View(customerAddressAccountViewModel);
        //}



        //// GET: Customers1/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var customer = await _context.Customers.FindAsync(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(customer);
        //}

        //// POST: Customers1/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,AddressId,AccountId,UserId")] Customer customer)
        //{
        //    if (id != customer.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(customer);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CustomerExists(customer.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", customer.AddressId);
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", customer.UserId);
        //    return View(customer);
        //}

        //// GET: Customers1/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var customer = await _context.Customers
        //        .Include(c => c.Address)
        //        .Include(c => c.IdentityUser)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(customer);
        //}

        //// POST: Customers1/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var customer = await _context.Customers.FindAsync(id);
        //    _context.Customers.Remove(customer);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CustomerExists(int id)
        //{
        //    return _context.Customers.Any(e => e.Id == id);
        //}
    }
}

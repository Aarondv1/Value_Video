﻿using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Value_Video.Migrations;
using Value_Video.Models;
using Value_Video.ViewModels;

namespace Value_Video.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
            
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        [Min18YearsIfMember]
        public ActionResult CustomerForm()
        {
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribed = customer.IsSubscribed;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        
        


        // GET: Customers
        public ViewResult Index()
        {
            return View();
        }

        //public ViewResult Detail(int id)
        //{
        //    return View(_context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id));

        //}

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()


            };

            return View("CustomerForm", viewModel);


        }
    }
}
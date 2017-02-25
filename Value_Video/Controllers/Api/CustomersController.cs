using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
//using System.Web.Mvc;
using System.Data.Entity;
using Value_Video.Dtos;
using Value_Video.Models;

namespace Value_Video.Controllers.Api
{
    public class CustomersController : ApiController
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






   
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers.Include(a => a.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(item => item.Name.Contains(query));

            var customers = customersQuery.ToList().Select(Mapper.Map<Customer, CustomerDto>);



            
            return Ok(customers);





        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
                return NotFound();




            return Ok(Mapper.Map<Customer,CustomerDto>(customer));


        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDto );


        }




        [HttpPut]
        public IHttpActionResult ChangeCustomer(CustomerDto customerDto, int id)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customerInDb == null)
                return NotFound();


            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);
            

            _context.SaveChanges();
            //return customerDto;
            return Ok();


        }

        [HttpDelete]
        public IHttpActionResult RemoveCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Ok();

        }

    }
}

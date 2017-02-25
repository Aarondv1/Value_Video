using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Value_Video.Dtos;
using Value_Video.Models;

namespace Value_Video.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        

            [HttpPost]
            public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
            {
                var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);
                var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

                foreach (var item in movies)
                {
                    var rental = new Rental()
                    {
                        Customer = customer,
                        Movie = item,
                        DateRented = DateTime.Now

                    };

                    item.NumberAvailable--;

                    _context.Rentals.Add(rental);

                }
                _context.SaveChanges();
                return Ok();
            }
    }
}


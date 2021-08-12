using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieApplication.Dtos;
using MovieApplication.Models;
using System.Data.Entity;
using System.EnterpriseServices;

namespace MovieApplication.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
           

            if (!ModelState.IsValid)
                return BadRequest();
            
            var customer = _context.customers.Single(c => c.Id == newRental.customerId);
            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();
            
            foreach (var movi in movies)
            {
                if (movi.NumberAvailable == 0)
                    return BadRequest("The Movie is not available");
                movi.NumberAvailable--;

                var rental = new Rental
                {
                    Customer= customer ,
                    DateRented = DateTime.Now,
                    Movie = movi
                    
                };
                _context.Rentals.Add(rental);

            }
            _context.SaveChanges();
            return Ok();
            
        }
    }
}

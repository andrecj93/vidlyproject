using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Glimpse.Core.Extensions;
using Vidly2.Dtos;
using Vidly2.Models;

namespace Vidly2.Controllers.API
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public  NewRentalsController()
        { 
            _context = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            var customerInDb = _context.Customers.Single(c => c.Id == newRentalDto.CustomerId);
            var moviesInDb = _context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in moviesInDb)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie - "+movie.Name+", is not available.");
                }

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Movie = movie,
                    Customer = customerInDb,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}

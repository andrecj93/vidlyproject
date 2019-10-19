using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Movies To Be Rented")]
        public Movie Movie { get; set; }
       
        [Required]
        public Customer Customer { get; set; }

        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }

    }
}
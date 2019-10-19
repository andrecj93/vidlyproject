using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }
        
        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1, 20, ErrorMessage = "The field number in Stock must be between 1 and 20")]
        public byte NumberInStock { get; set; }

        [Display(Name = "Number of movies available")]
        public byte NumberAvailable { get; set; }

    }
}
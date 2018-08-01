using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyUA.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Display(Name = "Genre Type")]
        public int GenreId { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleasedDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in Stock" )]
        public int NumberInStock { get; set; }

    }


}
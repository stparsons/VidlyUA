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
        public string Name { get; set; }

        [Required]
        public Genre Genre { get; set; }
        public int GenreId { get; set; }

        public DateTime ReleasedDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int NumberInStock { get; set; }

    }


}
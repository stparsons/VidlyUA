using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyUA.Models;

namespace VidlyUA.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength( 255 )]
        public string Name { get; set; }

        [Required]
        public int GenreId { get; set; }

        public DateTime ReleasedDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Range( 1, 20 )]
        public int NumberInStock { get; set; }
    }
}
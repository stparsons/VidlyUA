using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VidlyUA.Models;

namespace VidlyUA.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        [Required]
        public int? Id { get; set; }

        [Required]
        [StringLength( 255 )]
        [Display( Name = "Movie Name" )]
        public string Name { get; set; }

        [Required]
        [Display( Name = "Genre Type" )]
        public int? GenreId { get; set; }

        [Required]
        [Display( Name = "Release Date" )]
        public DateTime? ReleasedDate { get; set; }

        [Required]
        [Display( Name = "Number in Stock" )]
        [Range( 1, 20 )]
        public int? NumberInStock { get; set; }

        public string Title
        {
            get
            {
                return Id != null && Id !=0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleasedDate = movie.ReleasedDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}
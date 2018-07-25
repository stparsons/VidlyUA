using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyUA.Models;

namespace VidlyUA.Controllers
{
    public class MoviesController : Controller
    {
        public ViewResult Index()
        {
            var movies = GetMovies();

            return View(movies);    
        }

        public ActionResult Details( int id )
        {
            var movie = GetMovies().SingleOrDefault( c => c.Id == id );

            if ( movie == null )
                return HttpNotFound();

            return View( movie );
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }
 
    }
}
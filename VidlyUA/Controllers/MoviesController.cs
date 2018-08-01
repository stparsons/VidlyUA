using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyUA.Models;
using VidlyUA.ViewModels;

namespace VidlyUA.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var movies = _context.Movies.Include( c => c.Genre ).ToList();

            return View( movies );
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = genres
            };

            return View( "MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieToSave = _context.Movies.Single(c => c.Id == movie.Id);
                movieToSave.Name = movie.Name;
                movieToSave.GenreId = movie.GenreId;
                movieToSave.NumberInStock = movie.NumberInStock;
                movieToSave.ReleasedDate = movie.ReleasedDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index","Movies");
        }

        public ActionResult Details( int id )
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault( c => c.Id == id );

            if ( movie == null )
                return HttpNotFound();

            return View( movie );
        }

    }
}
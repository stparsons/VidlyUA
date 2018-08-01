using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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

        public ActionResult Edit( int id )
        {
            var movieInDbSingle = _context.Movies.SingleOrDefault( c => c.Id == id );

            if ( movieInDbSingle == null )
                return HttpNotFound();

            var viewModel = new MovieFormViewModel()
            {
                Movie = movieInDbSingle,
                Genres = _context.Genres.ToList()
            };

            return View( "MovieForm", viewModel );

        }

        public ActionResult Details( int id )
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault( c => c.Id == id );

            if ( movie == null )
                return HttpNotFound();

            return View( movie );
        }

        [HttpPost]
        public ActionResult Save( Movie movie )
        {
            if ( movie.Id == 0 )
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add( movie );
            }
            else
            {
                var movieinDb = _context.Movies.Single( c => c.Id == movie.Id );
                movieinDb.Name = movie.Name;
                movieinDb.GenreId = movie.GenreId;
                movieinDb.NumberInStock = movie.NumberInStock;
                movieinDb.ReleasedDate = movie.ReleasedDate;
            }

            try
            {
                _context.SaveChanges();
            }
            catch ( DbEntityValidationException e )
            {
                //
                // This catch is to figure out what a true exception is during a validation error
                // Used this to find that Genre was not being set correctly for Entity Framework
                // To see :
                //  1). Hit breakpoint
                //  2). Inspect e
                //  3). Click EntityValiationErrors [0]
                //  4). Epand ValidationErrors[0]
                //  5). ErrorMessage : "The Genre field is required"
                //
                // Fixed by moving [Required] attribute from Movie.Genre to Movie.GenreID
                //
                Console.WriteLine(e);
                throw;
            }

            return RedirectToAction( "Index", "Movies" );
        }

    }
}
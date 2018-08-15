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
            // 
            // Only allow users who can manage moves to the editable list view
            //
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }
            else
            {
                return View("ReadOnlyList");
            }
            
        }

        [Authorize(Roles = RoleName.CanManageMovies )] 
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = genres
            };

            return View( "MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit( int id )
        {
            var movie = _context.Movies.SingleOrDefault( c => c.Id == id );

            if ( movie == null )
                return HttpNotFound();

            var viewModel = new MovieFormViewModel( movie )
            {
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
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save( Movie movie )
        {
            if ( !ModelState.IsValid )
            {
                var genreTypes = _context.Genres.ToList();
                var movieView = new MovieFormViewModel(movie)
                {
                    Genres = genreTypes,
                };

                return View( "MovieForm", movieView );
            }

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
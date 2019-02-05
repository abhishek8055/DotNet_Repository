using MVCLoginPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVCLoginPortal.ViewModel;

namespace MVCLoginPortal.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        private ApplicationDbContext _appContext;
        public MovieController()
        {
            _appContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _appContext.Dispose();
        }

        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }
            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _appContext.Genres.ToList();
            var viewModel = new NewMovieViewModel()
            {
                Movie = new Movie(),
                Genres = genres
            };
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel
                {
                    Movie = movie,
                    Genres = _appContext.Genres.ToList()
                };
                return View("New", viewModel);
            }
            if (movie.Id == 0)
            {
                _appContext.Movies.Add(movie);
            }
            else
            {
                var dataInDB = _appContext.Movies.Single(c => c.Id == movie.Id);
                dataInDB.Name = movie.Name;
                dataInDB.ReleaseDate = movie.ReleaseDate;
                dataInDB.Genre = movie.Genre;
                dataInDB.GenreId = movie.GenreId;
                dataInDB.DateAdded = DateTime.Now;
                dataInDB.NumberInStock = movie.NumberInStock;
            }
            _appContext.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _appContext.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewMovieViewModel
            {
                Movie = movie,
                Genres = _appContext.Genres.ToList()
            };

            return View("New", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Delete(int id)
        {
            var movie = _appContext.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            _appContext.Movies.Remove(movie);
            _appContext.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }
    }
}
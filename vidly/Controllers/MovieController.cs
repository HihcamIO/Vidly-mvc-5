using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModel;

namespace vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movies
        public ActionResult ListOfMovies()
        {
            //var movie = new Models.Movie() { Name="Shrake!" };

            //ViewData["movie"] = movie;
            //ViewBag["movie"] = movie;

            //var viewResultat = new ViewResult();
            //viewResultat.Model 

            var lstOfMoviesViewModel = new MovieViewModel
            {
                Movies = GetMovies()
            }; 

            //return View(movie);
            return View(lstOfMoviesViewModel);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie(){ Id = 1, Name = "Movie 1" },
                new Movie(){ Id = 2, Name = "Movie 2" },
                new Movie(){ Id = 3, Name = "Movie 3" },
                new Movie(){ Id = 4, Name = "Movie 4" },
                new Movie(){ Id = 5, Name = "Movie 5" },
                new Movie(){ Id = 6, Name = "Movie 6" },
                new Movie(){ Id = 7, Name = "Movie 7" }
            };
        }

        public ActionResult DetailMovie(int id)
        {
            var movie = GetMovies().SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            MovieViewModel movieViewModel = new MovieViewModel();
            movieViewModel.Name = movie.Name;

            return View(movieViewModel);
        }

        public ActionResult Index(int? id, string name)
        {
            if (!id.HasValue)
                id = 1;

            if (!string.IsNullOrWhiteSpace("name"))
                name = "Hicham";
            
            return Content(String.Format("Id={0}&Name={1}",id,name));
        }

        [Route("Movies/SearchByDate/{annee}/{mois:regex(\\d{2}):range(1,12)}")]
        public ActionResult SearchByDate(int annee, int mois)
        {
            return Content(String.Format("Annee={0}&Mois={1}", annee, mois));
        }

    }
}
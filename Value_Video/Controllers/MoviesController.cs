using System;
using System.Linq;
using System.Web.Mvc;
using Value_Video.Models;
using Value_Video.ViewModels;


namespace Value_Video.Controllers
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

        


       

        
    

        // GET: Movies
        public ActionResult Index()
        {
           // return View(User.IsInRole(RoleName.CanManageMovies) ? "CanManageMovieIndex" : "Index");
            return View("CanManageMovieIndex");


            //return View();
        }

    //public ActionResult Detail(int id)
    //{
    //    return View(_context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id));
    //}
       // [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult MovieForm()
        {
            var viewModel = new MovieFormViewModel()
            {
                //Movie = new Movie(),
                Genres = _context.Genres.ToList()
            };

            return View(viewModel);
        }

       // [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(m => m.Id == id);
            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }


            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate  = movie.ReleaseDate;
                movieInDb.GenreId  = movie.GenreId;
                movieInDb.NumberInStock  = movie.NumberInStock;


            }
            _context.SaveChanges();


            return RedirectToAction("Index","Movies");
        }


        



        };

    
}
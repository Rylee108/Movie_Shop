using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> DetailsAsync(int id)
        {

            //go to database and get the movie information by movie id and send the data(model) to the view
            // use ADO.NET or Dapper to connect with the db.
            // Dapper  stcakoverflow -> Micro ORM
            // Entity FrameWork Core => Full ORM

            var movieDetails = await _movieService.GetMovieDetails(id);
            return View(movieDetails);
            // select * from Movies where id = 12;
            // Code is Maintenable, Reusable, Readable, Extensible, testable
            //layers = > layered architecture
            //Onion, clean
        }

        public async Task<ActionResult> MoviesByGenre(int id, int pageSize = 30, int page = 1)
        {
            var pagedMovies = await _movieService.GetMoviesByPagination(id, pageSize, page);
            return View(pagedMovies);
        }


    }
}

using ApplicationCore.Contracts.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Models;
using System.Diagnostics;

namespace MovieShopMVC.Controllers
{
    //controllers => Services (BL) =>Repositories => Database using EF Core or Dapper or both
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;
        public HomeController(ILogger<HomeController> logger,IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }
        
        //Action methods
        public async Task<IActionResult> Index()
        {
            //go to database and get the data
            //tightly coupled code
            //losely coupled code

            var movieCards = await _movieService.GetTopRevenueMovies();
            return View(movieCards);
            //IMovieServices test = new movieService();
            //var movieService = new MovieService();
            //3 ways we csn send the data from controller action method to views
            //ViewBag 
            //ViewData
            //*** Strongly typed models **
        }

        public IActionResult Privacy()
        {
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
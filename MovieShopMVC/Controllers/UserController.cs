using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Infra;
using Microsoft.AspNetCore.Authorization;

namespace MovieShopMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        

        private readonly ICurrentUser _currentUser;
        private readonly IUserService _userService;

        public UserController(ICurrentUser currentUser, IUserService userService)
        {
            _currentUser = currentUser;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Purchases()
        {
            var userId = _currentUser.UserId;
            var movies = await _userService.GetAllPurchasesForUser(userId);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {

            var userId = _currentUser.UserId;
            var movies = await _userService.GetAllFavoritesForUser(userId);
            return View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UserEditModel model)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> BuyMovie(int movieId)
        {
            var userId = _currentUser.UserId;
            PurchaseRequestModel model = new PurchaseRequestModel
            {
                MovieId = movieId,
                //Price = model.Price
                UserId = userId
            };
            var purchases = await _userService.PurchaseMovie(model, userId);

            return RedirectToAction("Details", "Movies", new { id = movieId });
        }

        [HttpGet]
        public async Task<IActionResult> FavoriteMovie(int movieId)
        {
            var userId = _currentUser.UserId;
            FavoriteRequestModel model = new FavoriteRequestModel
            {
                MovieId = movieId,
                UserId = userId
            };

            await _userService.AddFavorite(model);
            return RedirectToAction("Details", "Movies", new { id = movieId });
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFavorite(int movieId)
        {
            var userId = _currentUser.UserId;
            FavoriteRequestModel model = new FavoriteRequestModel
            {
                MovieId = movieId,
                UserId = userId
            };

            await _userService.RemoveFavorite(model);
            return RedirectToAction("Details", "Movies", new { id = movieId });
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(ReviewRequestModel model)
        {
            await _userService.AddMovieReview(model);
            return RedirectToAction("Details", "Movies", new { id = model.MovieId });
        }


    }
}

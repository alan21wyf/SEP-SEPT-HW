using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieShopMVC.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;

        public UserController(IUserService userService, ICurrentUserService currentUserService)
        {
            _userService = userService;
            _currentUserService = currentUserService;
        }

        [HttpPost]
        public async Task<IActionResult> Purchase()
        {

            return View();
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Purchases()
        {
            // get the id from httpcontext.user.claims
            //var userIdentity = this.User.Identity;
            //if (userIdentity != null && this.User.Identity.IsAuthenticated == true)
            //{
            //    // call the database to get the data
            //    int userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            //    var movieCards = await _userService.GetUserPurchases(userId);
            //    return View(movieCards);
            //}
            //return RedirectToAction("Login", "Account");

            //var userId = _currentUserService.UserId;
            var userIdentity = this.User.Identity;

            //pass the user Id to the userservice, that will pass to userrepository
            if (userIdentity != null && this.User.Identity.IsAuthenticated == true)
            {
                // call the database to get the data
                int userId  = _currentUserService.UserId;

                var movieCards = await _userService.GetUserPurchases(userId);
                return View(movieCards);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> Favorite()
        {
            var userIdentity = this.User.Identity;
            if (userIdentity != null && this.User.Identity.IsAuthenticated == true)
            {
                int userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                FavoriteRequestModel favoriteRequestModel = new FavoriteRequestModel
                {
                    MovieId = 2
                };
                await _userService.AddFavorite(favoriteRequestModel);
                return LocalRedirect("~/");
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            // get the id from httpcontext.user.claims
            var userIdentity = this.User.Identity;
            if (userIdentity != null && this.User.Identity.IsAuthenticated == true)
            {
                // call the database to get the data
                int userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var favorites = await _userService.GetUserFavorites(userId);
                return View(favorites);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> Review(ReviewRequestModel reviewRequestModel)
        {
            //use modal bootstrap
            return View();
        }

        [HttpGet]
        public IActionResult Review()
        {
            //use modal bootstrap
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Reviews(int id)
        {
            // get the id from httpcontext.user.claims
            var userIdentity = this.User.Identity;
            if (userIdentity != null && this.User.Identity.IsAuthenticated == true)
            {
                // call the database to get the data
                int userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var reviewModels = await _userService.GetUserReviews(userId);
                return View(reviewModels);
            }
            return RedirectToAction("Login", "Account");
        }
    }
}

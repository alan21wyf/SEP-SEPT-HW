using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public UserController(IUserService userService)
        {
            _userService = userService;
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
            var userIdentity = this.User.Identity;
            if (userIdentity != null && this.User.Identity.IsAuthenticated == true)
            {
                // call the database to get the data
                int userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var movieCards = await _userService.GetUserPurchases(userId);
                return View(movieCards);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> Favorite()
        {
            return View();
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
                var movieCards = await _userService.GetUserFavorites(userId);
                return View(movieCards);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> Review()
        {
            //use modal bootstrap
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Reviews(int id)
        {
            return View();
        }
    }
}

using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopMVC.Controllers
{
    public class PurchaseController : Controller
    {

        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;

        public PurchaseController(ICurrentUserService currentUserService, IUserService userService)
        {
            _currentUserService = currentUserService;
            _userService = userService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Details(PurchaseRequestModel favoriteRequestModel)
        {
            var userId = _currentUserService.UserId;
            await _userService.GetPurchasesDetails(favoriteRequestModel.MovieId, userId);
            return RedirectToAction("Favorites", "User");
        }
    }
}

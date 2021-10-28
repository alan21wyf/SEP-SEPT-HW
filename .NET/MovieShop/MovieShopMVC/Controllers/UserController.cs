using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopMVC.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Purchase()
        {

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Purchases(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Favorite()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Favorites(int id)
        {
            return View();
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

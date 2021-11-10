using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        // create an api method that shows top 30 revenue movies
        // so that my SPA, IOS and Android app show those movies in the home screen
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;

        public MoviesController(IMovieService movieService, IGenreService genreService)
        {
            _movieService = movieService;
            _genreService = genreService;

        }

        [HttpGet]
        [Route("toprevenue")]
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            var movies = await _movieService.GetTop30RevenueMovies();
            // return Json and http status code
            if (!movies.Any())
            {
                // return 404
                return NotFound("No Movies Found.");
            }
            // return 200 OK
            return Ok(movies);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetAllMovies();
            if (!movies.Any())
            {
                return NotFound("No Movies Found.");
            }
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _movieService.GetMovieDetails(id);

            if (movieDetails == null)
            {
                return NotFound($"No Movie Found For MovieId = {id}");
            }
            return Ok(movieDetails);
        }

        [HttpGet]
        [Route("toprated")]
        public async Task<IActionResult> GetTopratedMovies()
        {
            var movies = await _movieService.GetTopRatedMovies();
            if (movies == null)
            {
                return NotFound("No Movies Found.");
            }
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id:int}/reviews")]
        public async Task<IActionResult> GetReviewsByMovie(int id)
        {
            var reviews = await _movieService.GetMovieReviews(id);
            if (reviews == null)
            {
                return NotFound("No Reviews For This Movie Yet. Be the First One Here!");
            }
            return Ok(reviews);
        }



        [HttpGet]
        [Route("genre/{genreId:int}")]
        public async Task<IActionResult> GetMoviesByGenre(int genreId, [FromQuery] int pagesize = 30, [FromQuery] int pageIndex = 1)
        {
            // LinQ moviegenres.skip(pageindex-1).take(pagesize).tolistasync()
            var movies = await _genreService.GetMoviesByGenre(genreId);
            if (movies == null)
            {
                return NotFound("No Movies Found In This Genre.");
            }
            return Ok(movies);
        }
    }
}

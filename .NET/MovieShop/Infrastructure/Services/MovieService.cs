using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieService: IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<MovieDetailsResponseModel> GetMovieDetails(int id)
        {
            var movie = await _movieRepository.GetMovieById(id);
            if (movie == null)
            {
                throw new Exception($"No Movie Found for This {id}");
            }
            var movieDetails = new MovieDetailsResponseModel
            {
                Id = movie.Id,
                Budget = movie.Budget,
                Overview = movie.Overview,
                Price = movie.Price,
                PosterUrl = movie.PosterUrl,
                Revenue = movie.Revenue,
                ReleaseDate = movie.ReleaseDate.GetValueOrDefault(),
                Rating = movie.Rating,
                Tagline = movie.Tagline,
                Title = movie.Title,
                RunTime = movie.RunTime,
                BackdropUrl = movie.BackdropUrl,
                ImdbUrl = movie.ImdbUrl,
                TmdbUrl = movie.TmdbUrl
            };


            foreach (var genre in movie.Genres)
            {
                movieDetails.Genres.Add(new GenreModel
                {
                    Id = genre.GenreId,
                    Name = genre.Genre.Name
                });
            }

            foreach (var cast in movie.Casts)
            {
                movieDetails.Casts.Add(new CastResponseModel
                {
                    Id = cast.CastId,
                    Name = cast.Cast.Name,
                    Character = cast.Character,
                    ProfilePath = cast.Cast.ProfilePath
                });

            }

            foreach (var trailer in movie.Trailers)
            {
                movieDetails.Trailers.Add(new TrailerResponseModel
                {
                    Id = trailer.Id,
                    MovieId = trailer.MovieId,
                    Name = trailer.Name,
                    TrailerUrl = trailer.TrailerUrl
                });

            }

            return movieDetails;
        }

        public async Task<List<MovieCardResponseModel>> GetTop30RevenueMovies()
        {
            var movies = await _movieRepository.GetTop30RevenueMovies();
            List<MovieCardResponseModel> movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }

            return movieCards;
        }

        public async Task<List<MovieCardResponseModel>> GetAllMovies()
        {
            var movies = await _movieRepository.GetAll();
            List<MovieCardResponseModel> movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            return movieCards;
        }

        public async Task<List<MovieCardResponseModel>> GetTopRatedMovies()
        {
            var movies = await _movieRepository.GetHighest100RatedMovies();
            List<MovieCardResponseModel> movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            return movieCards;
        }

        public async Task<List<ReviewResponseModel>> GetMovieReviews(int id)
        {
            var movie = await _movieRepository.GetMovieById(id);
            var reviews = new List<ReviewResponseModel>();
            foreach (var review in movie.Reviews)
            {
                reviews.Add(new ReviewResponseModel
                {
                    MovieId = review.MovieId,
                    ReviewText = review.ReviewText,
                    Rating = review.Rating,
                });
            }
            return reviews;
        }
    }
}

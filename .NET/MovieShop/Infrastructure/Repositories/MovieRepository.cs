using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext):base(dbContext)
        {
        }
        public async Task<IEnumerable<Movie>> GetTop30RevenueMovies()
        {
            // use EF with LinQ to get top 30 Movies by revenue
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var movie = await _dbContext.Movies.Include(m => m.Casts).ThenInclude(m => m.Cast)
                .Include(m => m.Genres).ThenInclude(m => m.Genre).Include(m => m.Trailers).FirstOrDefaultAsync(m => m.Id == id);
            var movieRating = await _dbContext.Reviews.Where(r => r.MovieId == id).DefaultIfEmpty()
                .AverageAsync(r => r == null ? 0 : r.Rating);
            if (movieRating > 0) { movie.Rating = movieRating; }
            var reviews = await _dbContext.Reviews.Where(r => r.MovieId == id).ToListAsync();
            if (reviews != null)
            {
                movie.Reviews = reviews;
            }
            return movie;
        }

        public async Task<IEnumerable<Movie>> GetHighest100RatedMovies()
        {
            var topRatedMovies = await _dbContext.Reviews.Include(m => m.Movie)
                                     .GroupBy(r => new
                                     {
                                         Id = r.MovieId,
                                         r.Movie.PosterUrl,
                                         r.Movie.Title,
                                         r.Movie.ReleaseDate
                                     })
                                     .OrderByDescending(g => g.Average(m => m.Rating))
                                     .Select(m => new Movie
                                     {
                                         Id = m.Key.Id,
                                         PosterUrl = m.Key.PosterUrl,
                                         Title = m.Key.Title,
                                         ReleaseDate = m.Key.ReleaseDate,
                                         Rating = m.Average(x => x.Rating)
                                     })
                                     .Take(100)
                                     .ToListAsync();

            return topRatedMovies;
        }
    }
}

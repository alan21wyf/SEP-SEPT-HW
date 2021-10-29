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
    public class UserRepository : IUserRepository
    {
        private readonly MovieShopDbContext _dbContext;

        public UserRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<Movie>> GetFavoriteMovies(int id)
        {
            var favorites = await _dbContext.Favorites.Where(f => f.UserId == id).ToListAsync();
            List<Movie> movies = new List<Movie>();
            foreach (var favorite in favorites)
            {
                var movie = await _dbContext.Movies.Where(m => m.Id == favorite.MovieId).FirstOrDefaultAsync();
                movies.Add(movie);
            }
            return movies;   
        }

        public async Task<IEnumerable<Movie>> GetPurchasedMovies(int id)
        {
            var purchases = await _dbContext.Purchases.Where(p => p.UserId == id).ToListAsync();
            List<Movie> movies = new List<Movie>();
            foreach (var purchase in purchases)
            {
                var movie = await _dbContext.Movies.Where(m => m.Id == purchase.MovieId).FirstOrDefaultAsync();
                movies.Add(movie);
            }
            return movies;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }
    }
}

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
    public class GenreRepository: EfRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenre(int id)
        {

            var moviesByGenre = await _dbContext.Genres.Where(g => g.Id == id).Include(g => g.Movies).SelectMany(gm => gm.Movies).Include(g => g.Movie).Select(g => g.Movie).ToListAsync();

            return moviesByGenre;
        }
    }
}

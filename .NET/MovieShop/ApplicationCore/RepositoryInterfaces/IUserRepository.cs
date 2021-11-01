using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IUserRepository:IAsyncRepository<User>
    {
        Task<User> GetUserByEmail(string email);

        Task<IEnumerable<Movie>> GetPurchasedMovies(int id);
        Task<IEnumerable<Movie>> GetFavoriteMovies(int id);
        Task<IEnumerable<Review>> GetMovieReviews(int id);
    }
}

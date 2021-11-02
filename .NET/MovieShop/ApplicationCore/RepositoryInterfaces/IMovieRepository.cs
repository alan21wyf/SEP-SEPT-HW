using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IMovieRepository: IAsyncRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetTop30RevenueMovies();
        Task<Movie> GetMovieById(int id);
        Task<IEnumerable<Movie>> GetHighest100RatedMovies();

    }
}

using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        Task<List<MovieCardResponseModel>> GetTop30RevenueMovies();
        Task<List<MovieCardResponseModel>> GetAllMovies();
        Task<MovieDetailsResponseModel> GetMovieDetails(int id);
        Task<List<MovieCardResponseModel>> GetTopRatedMovies();
        Task<List<ReviewResponseModel>> GetMovieReviews(int id);

    }
}

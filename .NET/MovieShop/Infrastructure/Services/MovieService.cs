using ApplicationCore.Models;
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
        public List<MovieCardResponseModel> GetTop30RevenueMovies()
        {
            var movieCards = new List<MovieCardResponseModel> {
                new MovieCardResponseModel{ ID = 1, Title = "Inception", PosterUrl = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"}
            };

            return movieCards;
        }
    }
}

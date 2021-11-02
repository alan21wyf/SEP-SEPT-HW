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
    public class CastService: ICastService
    {
        private readonly ICastRepository _castRepository;
        private readonly IMovieRepository _movieRepository;

        public CastService(ICastRepository castRepository, IMovieRepository movieRepository)
        {
            _castRepository = castRepository;
            _movieRepository = movieRepository;

        }

        public async Task<CastDetailsResponseModel> GetCastById(int id)
        {
            var cast = await _castRepository.GetCastById(id);
            if (cast == null)
            {
                throw new Exception($"No Cast Found for Id = {id}");
            }
            var castModel = new CastDetailsResponseModel 
            {
                Id = cast.Id,
                Gender = cast.Gender,
                Name = cast.Name,
                ProfilePath = cast.ProfilePath,
                TmdbUrl = cast.TmdbUrl
            };
            foreach (var movie in cast.Movies)
            {
                var movieInfo = await _movieRepository.GetMovieById(movie.MovieId);
                castModel.Movies.Add(new MovieCastResponseModel
                {
                    Id = movie.MovieId,
                    Character = movie.Character,
                    PosterUrl = movie.Movie.PosterUrl,
                    Title = movie.Movie.Title,
                    Revenue = movie.Movie.Revenue.GetValueOrDefault(),
                    Rating = movieInfo.Rating.GetValueOrDefault()

                }) ;
            }
            return castModel;
        }
    }
}

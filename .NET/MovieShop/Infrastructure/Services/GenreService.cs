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
    public class GenreService:IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<GenreModel>> GetAllGenres()
        {
            var genres = await _genreRepository.GetAll();
            var genresModel = new List<GenreModel>();
            foreach (var genre in genres)
            {
                genresModel.Add(new GenreModel
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            }
            return genresModel;
        }

        public async Task<List<MovieCardResponseModel>> GetMoviesByGenre(int id)
        {
            var movies = await _genreRepository.GetMoviesByGenre(id);
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    Title = movie.Title
                });
            }
            return movieCards;
        }
    }
}

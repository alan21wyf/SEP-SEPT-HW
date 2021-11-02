using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class CastDetailsResponseModel
    {
        public CastDetailsResponseModel()
        {
            Movies = new List<MovieCastResponseModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string TmdbUrl { get; set; }
        public string ProfilePath { get; set; }
        public List<MovieCastResponseModel> Movies { get; set; }
    }

    public class MovieCastResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public string Character { get; set; }
        public decimal Revenue { get; set; }
        public decimal Rating { get; set; }
    }
}

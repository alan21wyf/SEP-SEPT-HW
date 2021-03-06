using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class PurchaseResponseModel
    {
        public int UserId { get; set; }
        public int TotalMoviesPurchased { get; set; }
        public List<PurchasedMovieResponseModel> PurchasedMovies { get; set; }

        public class PurchasedMovieResponseModel : MovieCardResponseModel
        {
            public PurchaseDetailsResponseModel Details { get; set; }
        }
    }
}

using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<int> ResigerUser(UserRegisterRequestModel requestModel);
        Task<UserLoginResponseModel> LoginUser(UserLoginRequestModel requestModel);

        Task AddFavorite(FavoriteRequestModel favoriteRequestModel, int userId);
        Task RemoveFavorite(FavoriteRequestModel favoriteRequestModel, int userId);
        Task<FavoriteResponseModel> GetUserFavorites(int id);


        Task AddMovieReview(ReviewRequestModel reviewRequest);
        Task UpdateMovieReview(ReviewRequestModel reviewRequest);
        Task DeleteMovieReview(int userId, int movieId);
        Task<List<UserReviewResponseModel>> GetUserReviews(int id);


        Task<bool> PurchaseMovie(PurchaseRequestModel purchaseRequest, int userId);
        Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId);
        Task<PurchaseResponseModel> GetUserPurchases(int id);
        Task<PurchaseDetailsResponseModel> GetPurchasesDetails(int userId, int movieId);
    }
}

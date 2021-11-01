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

        Task AddFavorite(FavoriteRequestModel favoriteRequestModel);
        Task RemovieFavorite(FavoriteRequestModel favoriteRequestModel);
        Task<List<FavoriteResponseModel>> GetUserFavorites(int id);


        Task AddMovieReview(ReviewRequestModel reviewRequest);
        Task UpdateMovieReview(ReviewRequestModel reviewRequest);
        Task DeleteMovieReview(int userId, int movieId);
        Task<List<UserReviewResponseModel>> GetUserReviews(int id);


        Task<bool> PurchaseMovie(PurchaseRequestModel purchaseRequest, int userId);
        Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId);
        Task<List<PurchaseResponseModel>> GetUserPurchases(int id);
        Task<PurchaseDetailsResponseModel> GetPurchasesDetails(int userId, int movieId);
    }
}

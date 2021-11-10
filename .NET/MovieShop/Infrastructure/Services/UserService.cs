using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static ApplicationCore.Models.FavoriteResponseModel;
using static ApplicationCore.Models.PurchaseResponseModel;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IMovieRepository _movieRepository;

        public UserService(IUserRepository userRepository, IPurchaseRepository purchaseRepository, IFavoriteRepository favoriteRepository, IReviewRepository reviewRepository, IMovieRepository movieRepository)
        {
            _userRepository = userRepository;
            _purchaseRepository = purchaseRepository;
            _favoriteRepository = favoriteRepository;
            _reviewRepository = reviewRepository;
            _movieRepository = movieRepository;
        }

        public async Task<int> ResigerUser(UserRegisterRequestModel requestModel)
        {
            var dbUser = await _userRepository.GetUserByEmail(requestModel.Email);
            if (dbUser != null)
            {
                throw new Exception("Email Already Exists, Please Login.");
            }
            //Generate a random unique salt
            var salt = GetSalt();

            //create the hashed password with salt
            var hashedPassword = GetHashedPassword(requestModel.Password, salt);

            //save the user object to db
            var user = new User
            {
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName,
                Email = requestModel.Email,
                Salt = salt,
                HashedPassword = hashedPassword,
                DateOfBirth = requestModel.DateOfBirth
            };

            var newUser = await _userRepository.Add(user);
            return newUser.Id;
        }

        private string GetSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string GetHashedPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }

        public async Task<UserLoginResponseModel> LoginUser(UserLoginRequestModel requestModel)
        {
            var dbUser = await _userRepository.GetUserByEmail(requestModel.Email);
            if (dbUser == null)
            {
                throw null;
            }

            var hashedPassword = GetHashedPassword(requestModel.Password, dbUser.Salt);

            if (hashedPassword == dbUser.HashedPassword)
            {
                var userLoginResponseModel = new UserLoginResponseModel
                {
                    Id = dbUser.Id,
                    FirstName = dbUser.FirstName,
                    LastName = dbUser.LastName,
                    DateOfBirth = dbUser.DateOfBirth.GetValueOrDefault(),
                    Email = dbUser.Email
                };
                return userLoginResponseModel;
            }

            return null;
        }





        //public async Task<List<MovieCardResponseModel>> GetUserPurchases(int id)
        //{
        //    var movies = await _userRepository.GetPurchasedMovies(id);
        //    List<MovieCardResponseModel> purchases = new List<MovieCardResponseModel> ();
        //    foreach (var movie in movies)
        //    {
        //        purchases.Add(new MovieCardResponseModel
        //        {
        //            Id = movie.Id,
        //            Title = movie.Title,
        //            PosterUrl = movie.PosterUrl
        //        });
        //    }
        //    return purchases;
        //}

        //public async Task<List<MovieCardResponseModel>> GetUserFavorites(int id)
        //{
        //    var movies = await _userRepository.GetFavoriteMovies(id);
        //    List<MovieCardResponseModel> favorites = new List<MovieCardResponseModel>();
        //    foreach (var movie in movies)
        //    {
        //        favorites.Add(new MovieCardResponseModel
        //        {
        //            Id = movie.Id,
        //            Title = movie.Title,
        //            PosterUrl = movie.PosterUrl
        //        });
        //    }
        //    return favorites;
        //}






        public async Task AddFavorite(FavoriteRequestModel favoriteRequestModel, int userId)
        {
            var favorited = await _favoriteRepository.Get(f => f.UserId == userId && f.MovieId == favoriteRequestModel.MovieId);
            if (favorited.Count() != 0)
            {
                throw new Exception("You have already favorited this movie.");
            }
            var favorite = new Favorite
            {
                MovieId = favoriteRequestModel.MovieId,
                UserId = userId
            };

            var dbFavorite = await _favoriteRepository.Add(favorite);
        }

        public async Task RemoveFavorite(FavoriteRequestModel favoriteRequestModel, int userId)
        {
            var dbFavorite = await _favoriteRepository.Get(f => f.MovieId == favoriteRequestModel.MovieId && f.UserId == userId);
            if (dbFavorite.Count() == 0)
            {
                throw new Exception("You haven't Favorite the Movie yet.");
            }
            await _favoriteRepository.Delete(dbFavorite.First());
        }

        public async Task<FavoriteResponseModel> GetUserFavorites(int id)
        {
            var movies = await _userRepository.GetFavoriteMovies(id);
            List<FavoriteMovieResponseModel> favoriteMovieCards = new List<FavoriteMovieResponseModel>();
            foreach (var movie in movies)
            {
                favoriteMovieCards.Add(new FavoriteMovieResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            FavoriteResponseModel favoriteResponseModel = new FavoriteResponseModel 
            {
                UserId = id,
                FavoriteMovies = favoriteMovieCards
            };
            return favoriteResponseModel;
        }


        public async Task AddMovieReview(ReviewRequestModel reviewRequest)
        {
            var review = new Review
            {
                MovieId = reviewRequest.MovieId,
                UserId = reviewRequest.UserId,
                ReviewText = reviewRequest.ReviewText,
                Rating = reviewRequest.Rating
            };

            await _reviewRepository.Add(review);
        }

        public Task UpdateMovieReview(ReviewRequestModel reviewRequest)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMovieReview(int userId, int movieId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserReviewResponseModel>> GetUserReviews(int id)
        {
            var reviews = await _userRepository.GetMovieReviews(id);
            List<UserReviewResponseModel> reviewModels = new List<UserReviewResponseModel>();
            foreach (var review in reviews)
            {
                reviewModels.Add(new UserReviewResponseModel
                {
                    MovieId = review.MovieId,
                    Title = review.Movie.Title,
                    PosterUrl = review.Movie.PosterUrl,
                    Rating = review.Rating,
                    ReviewText = review.ReviewText
                });
            }
            return reviewModels;
        }



        public async Task<bool> PurchaseMovie(PurchaseRequestModel purchaseRequest, int userId)
        {
            if (await IsMoviePurchased(purchaseRequest, userId))
            {
                throw new Exception("You have already purchased this movie.");
            }

            var movie = await _movieRepository.GetMovieById(purchaseRequest.MovieId);

            Purchase purchase = new Purchase
            {
                MovieId = purchaseRequest.MovieId,
                UserId = userId,
                TotalPrice = movie.Price.GetValueOrDefault(),
                PurchaseDateTime = purchaseRequest.PurchaseDateTime.GetValueOrDefault(),
                PurchaseNumber = purchaseRequest.PurchaseNumber.GetValueOrDefault()
            };
            var p = await _purchaseRepository.Add(purchase);
            return p == null ? false : true;
        }

        public async Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId)
        {
            var purchase = await _purchaseRepository.Get(p => p.MovieId == purchaseRequest.MovieId && p.UserId == userId);
            if (purchase.Count() == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<PurchaseResponseModel> GetUserPurchases(int id)
        {
            var movies = await _userRepository.GetPurchasedMovies(id);
            List<PurchasedMovieResponseModel> purchasedMovieCards = new List<PurchasedMovieResponseModel>();
            foreach (var movie in movies)
            {
                purchasedMovieCards.Add(new PurchasedMovieResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    Title = movie.Title,
                    Details = await GetPurchasesDetails(id, movie.Id)
                });
            }
            PurchaseResponseModel purchases = new PurchaseResponseModel
            {
                UserId = id,
                TotalMoviesPurchased = purchasedMovieCards.Count,
                PurchasedMovies = purchasedMovieCards
            };
            return purchases;
        }

        public async Task<PurchaseDetailsResponseModel> GetPurchasesDetails(int userId, int movieId)
        {
            var purchase = (await _purchaseRepository.Get(p => p.MovieId == movieId && p.UserId == userId)).FirstOrDefault();
            PurchaseDetailsResponseModel purchaseDetailsResponseModel = new PurchaseDetailsResponseModel
            {
                Id = purchase.Id,
                UserId = purchase.UserId,
                PurchaseNumber = purchase.PurchaseNumber,
                TotalPrice = purchase.TotalPrice,
                PurchaseDateTime = purchase.PurchaseDateTime,
                MovieId = purchase.MovieId,
                Title = purchase.Movie.Title,
                PosterUrl = purchase.Movie.PosterUrl,
                ReleaseDate = purchase.Movie.ReleaseDate
            };
            return purchaseDetailsResponseModel;

        }
    }
}

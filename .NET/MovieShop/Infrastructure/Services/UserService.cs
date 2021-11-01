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

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IFavoriteRepository _favoriteRepository;

        public UserService(IUserRepository userRepository, IPurchaseRepository purchaseRepository, IFavoriteRepository favoriteRepository, IReviewRepository reviewRepository)
        {
            _userRepository = userRepository;
            _purchaseRepository = purchaseRepository;
            _favoriteRepository = favoriteRepository;
            _reviewRepository = reviewRepository;
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






        public async Task AddFavorite(FavoriteRequestModel favoriteRequestModel)
        {
            var favorite = new Favorite
            {
                MovieId = favoriteRequestModel.MovieId,
                UserId = favoriteRequestModel.UserId
            };

            await _favoriteRepository.Add(favorite);
        }

        public async Task RemovieFavorite(FavoriteRequestModel favoriteRequestModel)
        {
            var dbFavorite = await _favoriteRepository.GetById(favoriteRequestModel.Id);
            if (dbFavorite==null)
            {
                throw new Exception("You haven't Favorite the Movie yet.");
            }
            await _favoriteRepository.Delete(dbFavorite);
        }

        public async Task<List<FavoriteResponseModel>> GetUserFavorites(int id)
        {
            var movies = await _userRepository.GetFavoriteMovies(id);
            List<FavoriteResponseModel> favorites = new List<FavoriteResponseModel>();
            foreach (var movie in movies)
            {
                favorites.Add(new FavoriteResponseModel
                {
                    MovieId = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            return favorites;
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
            Purchase purchase = new Purchase
            {
                MovieId = purchaseRequest.MovieId,
                UserId = purchaseRequest.UserId,
                PurchaseDateTime = DateTime.Now,
                PurchaseNumber = Guid.NewGuid(),
                TotalPrice = purchaseRequest.TotalPrice
            };
            var p = await _purchaseRepository.Add(purchase);
            return p == null ? false : true;
        }

        public async Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PurchaseResponseModel>> GetUserPurchases(int id)
        {
            var movies = await _userRepository.GetPurchasedMovies(id);
            List<PurchaseResponseModel> purchases = new List<PurchaseResponseModel>();
            foreach (var movie in movies)
            {
                purchases.Add(new PurchaseResponseModel
                {
                    MovieId = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            return purchases;
        }

        public Task<PurchaseDetailsResponseModel> GetPurchasesDetails(int userId, int movieId)
        {
            throw new NotImplementedException();
        }
    }
}

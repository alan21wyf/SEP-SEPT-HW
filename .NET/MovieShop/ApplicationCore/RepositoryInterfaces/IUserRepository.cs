﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(string email);
        Task<User> AddUser(User user);

        Task<IEnumerable<Movie>> GetPurchasedMovies(int id);
        Task<IEnumerable<Movie>> GetFavoriteMovies(int id);
    }
}

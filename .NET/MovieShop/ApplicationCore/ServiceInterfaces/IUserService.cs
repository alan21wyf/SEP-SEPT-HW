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
        Task<List<MovieCardResponseModel>> GetUserPurchases(int id);
        Task<List<MovieCardResponseModel>> GetUserFavorites(int id);
    }
}

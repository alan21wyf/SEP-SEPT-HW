using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IPlaceService
    {
        Task<List<PlaceResponseModel>> GetAllPlaces();
        Task<PlaceResponseModel> GetPlaceById(int id);
        Task<PlaceResponseModel> CreatePlace(PlaceRequestModel requestModel);
        //Task UpdatePlace(PlaceUpdateRequestModel requestModel);
        Task<PlaceResponseModel> UpdatePlace(PlaceUpdateRequestModel requestModel);
        Task<PlaceResponseModel> DeletePlace(int placeId);
    }
}

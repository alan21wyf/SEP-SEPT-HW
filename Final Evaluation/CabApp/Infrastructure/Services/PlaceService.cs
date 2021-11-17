using ApplicationCore.Entities;
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
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;

        public PlaceService(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public async Task<PlaceResponseModel> CreatePlace(PlaceRequestModel requestModel)
        {
            var dbPlace = await _placeRepository.Get(c => c.PlaceName == requestModel.PlaceName);
            if (dbPlace.FirstOrDefault() != null)
            {
                throw new Exception("This Place Already Exists.");
            }
            var newPlace = new Place
            {
                PlaceName = requestModel.PlaceName
            };
            var p = await _placeRepository.Add(newPlace);
            var created = new PlaceResponseModel
            {
                Id = p.PlaceId,
                PlaceName = p.PlaceName
            };
            return created;
        }

        public async Task<PlaceResponseModel> DeletePlace(int placeId)
        {
            var place = await _placeRepository.GetById(placeId);
            if (place == null)
            {
                throw new Exception($"Place With ID = {placeId} Does Not Exist.");
            }
            var deleted = await _placeRepository.Delete(place);
            var model = new PlaceResponseModel
            {
                Id = deleted.PlaceId,
                PlaceName = deleted.PlaceName
            };
            return model;
        }

        public async Task<List<PlaceResponseModel>> GetAllPlaces()
        {
            var places = await _placeRepository.GetAll();
            var models = new List<PlaceResponseModel>();
            foreach (var item in places)
            {
                models.Add(new PlaceResponseModel
                {
                    Id = item.PlaceId,
                    PlaceName = item.PlaceName
                });
            }

            return models;
        }

        public async Task<PlaceResponseModel> GetPlaceById(int id)
        {
            var place = await _placeRepository.GetById(id);
            if (place == null)
            {
                throw new Exception($"Cab Type With ID = {id} Does Not Exist.");
            }
            var model = new PlaceResponseModel
            {
                Id = place.PlaceId,
                PlaceName = place.PlaceName
            };
            return model;
        }

        public async Task<PlaceResponseModel> UpdatePlace(PlaceUpdateRequestModel requestModel)
        {
            var dbPlace = await _placeRepository.Get(p => p.PlaceName == requestModel.OldPlaceName);
            if (dbPlace == null || dbPlace.Count() == 0)
            {
                throw new Exception($"Place {requestModel.OldPlaceName} Does Not Exist.");
            }
            
            var newPlace = new Place
            {
                PlaceId = dbPlace.FirstOrDefault().PlaceId,
                PlaceName = requestModel.NewPlaceName
            };

            var place = await _placeRepository.Update(newPlace);
            var model = new PlaceResponseModel
            {
                Id = place.PlaceId,
                PlaceName = place.PlaceName
            };
            return model;
        }

        //public async Task UpdatePlace(PlaceUpdateRequestModel requestModel)
        //{
        //    var dbPlace = await _placeRepository.Get(c => c.PlaceName == requestModel.OldPlaceName);
        //    if (dbPlace.FirstOrDefault() == null)
        //    {
        //        throw new Exception($"Place {requestModel.OldPlaceName} Does Not Exist.");
        //    }
        //    var newPlace = new Place
        //    {
        //        PlaceId = dbPlace.FirstOrDefault().PlaceId,
        //        PlaceName = requestModel.NewPlaceName
        //    };

        //    var updated = await _placeRepository.Update(newPlace);
        //}
    }
}

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
    public class CabTypeService : ICabTypeService
    {
        private readonly ICabTypeRepository _cabTypeRepository;

        public CabTypeService(ICabTypeRepository cabTypeRepository)
        {
            _cabTypeRepository = cabTypeRepository;
        }

        public async Task<CabTypeResponseModel> CreateCabType(CabTypeRequestModel requestModel)
        {
            var cabType = await _cabTypeRepository.Get(c => c.CabTypeName == requestModel.CabTypeName);
            if (cabType.FirstOrDefault() != null)
            {
                throw new Exception("This Cab Type Already Exists.");
            }
            var newCabType = new CabType
            {
                CabTypeName = requestModel.CabTypeName
            };
            var c = await _cabTypeRepository.Add(newCabType);
            var created = new CabTypeResponseModel
            {
                Id = c.CabTypeId,
                CabTypeName = c.CabTypeName
            };
            return created;
        }

        public async Task<CabTypeResponseModel> DeleteCabType(int cabTypeId)
        {
            var cab = await _cabTypeRepository.GetById(cabTypeId);
            if (cab == null)
            {
                throw new Exception($"Cab Type With ID = {cabTypeId} Does Not Exist.");
            }
            await _cabTypeRepository.Delete(cab);
            var model = new CabTypeResponseModel
            {
                Id = cab.CabTypeId,
                CabTypeName = cab.CabTypeName
            };
            return model;
        }

        public async Task<List<CabTypeResponseModel>> GetAllCabTypes()
        {
            var cabTypes = await _cabTypeRepository.GetAll();
            var models = new List<CabTypeResponseModel>();
            foreach (var item in cabTypes)
            {
                models.Add(new CabTypeResponseModel
                {
                    Id = item.CabTypeId,
                    CabTypeName = item.CabTypeName
                });
            }

            return models;
        }

        public async Task<CabTypeResponseModel> GetCabTypeById(int id)
        {
            var cab = await _cabTypeRepository.GetById(id);
            if (cab == null)
            {
                throw new Exception($"Cab Type With ID = {id} Does Not Exist.");
            }
            var model = new CabTypeResponseModel
            {
                Id = cab.CabTypeId,
                CabTypeName = cab.CabTypeName
            };
            return model;
        }

        public async Task<CabTypeResponseModel> UpdateCabType(CabTypeUpdateRequestModel requestModel)
        {
            var dbCabType = await _cabTypeRepository.Get(c => c.CabTypeName == requestModel.OldCabTypeName);
            if (dbCabType.FirstOrDefault() == null)
            {
                throw new Exception($"Cab Type {requestModel.OldCabTypeName} Does Not Exist.");
            }
            var newCabType = new CabType
            {
                CabTypeId = dbCabType.FirstOrDefault().CabTypeId,
                CabTypeName = requestModel.NewCabTypeName
            };

            var updated = await _cabTypeRepository.Update(newCabType);

            var model = new CabTypeResponseModel
            {
                Id = updated.CabTypeId,
                CabTypeName = updated.CabTypeName
            };
            return model;
        }
    }
}

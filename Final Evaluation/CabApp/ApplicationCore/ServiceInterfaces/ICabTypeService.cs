using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ICabTypeService
    {
        Task<List<CabTypeResponseModel>> GetAllCabTypes();
        Task<CabTypeResponseModel> GetCabTypeById(int id);
        Task<CabTypeResponseModel> CreateCabType(CabTypeRequestModel requestModel);
        Task<CabTypeResponseModel> UpdateCabType(CabTypeUpdateRequestModel requestModel);
        Task<CabTypeResponseModel> DeleteCabType(int cabTypeId);

    }
}

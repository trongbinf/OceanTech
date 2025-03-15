using BusinessModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IDistrictService
    {
        Task<IEnumerable<District>> GetDistricts();
        Task<District> GetDistrictById(int id);
        Task<bool> CreateDistrict(District District);
        Task<bool> UpdateDistrict(District District);
        Task<bool> DeleteDistrict(int id);
    }
}

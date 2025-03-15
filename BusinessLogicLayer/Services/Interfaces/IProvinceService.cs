using BusinessModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IProvinceService
    {
        Task<IEnumerable<Province>> GetProvinces();
        Task<Province> GetProvinceById(int id);
        Task<bool> CreateProvince(Province province);
        Task<bool> UpdateProvince(Province province);
        Task<bool> DeleteProvince(int id);
    }
}

using BusinessModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IWardService
    {
        Task<IEnumerable<Ward>> GetWards();
        Task<IEnumerable<Ward>> GetWardsByDistrictId(int districtId);
        Task<Ward> GetWardByName(string name);

        Task<Ward> GetWardById(int id);
        Task<bool> CreateWard(Ward Ward);
        Task<bool> UpdateWard(Ward Ward);
        Task<bool> DeleteWard(int id);
    }
}

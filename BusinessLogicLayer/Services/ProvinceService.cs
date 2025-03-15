using BusinessLogicLayer.Services.Interfaces;
using BusinessModels.Entities;
using DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ProvinceService : IProvinceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProvinceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateProvince(Province province)
        {
            var result = await _unitOfWork.Provinces.AddAsync(province);
            await _unitOfWork.CompleteAsync();
            return result;
        }

        public async Task<bool> DeleteProvince(int id)
        {
            var result = await _unitOfWork.Provinces.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            return result;
        }

        public async Task<Province> GetProvinceById(int id)
        {
            return await _unitOfWork.Provinces.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Province>> GetProvinces()
        {
            return await _unitOfWork.Provinces.GetAllAsync();
        }

        public async Task<bool> UpdateProvince(Province province)
        {
            var result = await _unitOfWork.Provinces.UpdateAsync(province);
            await _unitOfWork.CompleteAsync();
            return result;
        }
    }
}

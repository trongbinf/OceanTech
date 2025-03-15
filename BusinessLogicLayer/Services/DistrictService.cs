using BusinessLogicLayer.Services.Interfaces;
using BusinessModels.Entities;
using DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DistrictService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<District>> GetDistricts()
        {
            return await _unitOfWork.Districts.GetAllAsync();
        }

        public async Task<District> GetDistrictById(int id)
        {
            return await _unitOfWork.Districts.GetByIdAsync(id);
        }

        public async Task<bool> CreateDistrict(District district)
        {
            if (district == null) return false;

            await _unitOfWork.Districts.AddAsync(district);
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<bool> UpdateDistrict(District district)
        {
            var existingDistrict = await _unitOfWork.Districts.GetByIdAsync(district.Id);
            if (existingDistrict == null) return false;

            // Cập nhật dữ liệu
            existingDistrict.Name = district.Name;
            existingDistrict.ProvinceId = district.ProvinceId;

            await _unitOfWork.Districts.UpdateAsync(existingDistrict);
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<bool> DeleteDistrict(int id)
        {
            var district = await _unitOfWork.Districts.GetByIdAsync(id);
            if (district == null) return false;

            await _unitOfWork.Districts.DeleteAsync(id);
            return await _unitOfWork.CompleteAsync() > 0;
        }
    }
}

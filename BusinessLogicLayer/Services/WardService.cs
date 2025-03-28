using BusinessLogicLayer.Services.Interfaces;
using BusinessModels.Entities;
using DataAccessLayer.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class WardService : IWardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Ward>> GetWards()
        {
            return await _unitOfWork.Wards.GetAllAsync( 
                include: query => query.Include(o => o.District)
                           
                           .ThenInclude(od => od.Province)
                           );
        }

        public async Task<Ward> GetWardById(int id)
        {
            return await _unitOfWork.Wards.GetByIdAsync(id, w => w.District, w => w.District.Province);
        }
        public async Task<Ward> GetWardByName(string name)
        {
            return (await _unitOfWork.Wards.GetByDelegateAsync(w => w.Name == name, w => w.District, w => w.District.Province)).FirstOrDefault();
        }

        public async Task<bool> CreateWard(Ward ward)
        {
            if (ward == null) return false;

            await _unitOfWork.Wards.AddAsync(ward);
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<bool> UpdateWard(Ward ward)
        {
            var existingWard = await _unitOfWork.Wards.GetByIdAsync(ward.Id);
            if (existingWard == null) return false;

            // Cập nhật dữ liệu
            existingWard.Name = ward.Name;
            existingWard.DistrictId = ward.DistrictId;

            await _unitOfWork.Wards.UpdateAsync(existingWard);
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<bool> DeleteWard(int id)
        {
            var ward = await _unitOfWork.Wards.GetByIdAsync(id);
            if (ward == null) return false;

            await _unitOfWork.Wards.DeleteAsync(id);
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<IEnumerable<Ward>> GetWardsByDistrictId(int districtId)
        {
            return await _unitOfWork.Wards.GetByDelegateAsync(w => w.DistrictId == districtId);
        }
    }
}

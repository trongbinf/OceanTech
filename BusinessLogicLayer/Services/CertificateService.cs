using BusinessLogicLayer.Services.Interfaces;
using BusinessModels.Entities;
using DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CertificateService : ICertificateService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CertificateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Certificate>> GetCertificates()
        {
            return await _unitOfWork.Certificates.GetAllAsync();
        }

        public async Task<Certificate> GetCertificateById(int id)
        {
            return await _unitOfWork.Certificates.GetByIdAsync(id);
        }

        public async Task<bool> CreateCertificate(Certificate certificate)
        {
            if (certificate == null) return false;

            await _unitOfWork.Certificates.AddAsync(certificate);
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<bool> UpdateCertificate(Certificate certificate)
        {
            var existingCertificate = await _unitOfWork.Certificates.GetByIdAsync(certificate.Id);
            if (existingCertificate == null) return false;

            // Cập nhật dữ liệu
            existingCertificate.Name = certificate.Name;
            existingCertificate.Description = certificate.Description;
            existingCertificate.EmployeeId = certificate.EmployeeId;
            existingCertificate.DateOfIssue = certificate.DateOfIssue;
            existingCertificate.DateOfExpiry = certificate.DateOfExpiry;
            existingCertificate.ProvinceId = certificate.ProvinceId;

            await _unitOfWork.Certificates.UpdateAsync(existingCertificate);
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<bool> DeleteCertificate(int id)
        {
            var certificate = await _unitOfWork.Certificates.GetByIdAsync(id);
            if (certificate == null) return false;

            await _unitOfWork.Certificates.DeleteAsync(id);
            return await _unitOfWork.CompleteAsync() > 0;
        }
    }
}

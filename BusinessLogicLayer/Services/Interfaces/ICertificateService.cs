using BusinessModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ICertificateService
    {
        Task<IEnumerable<Certificate>> GetCertificates();
        Task<Certificate> GetCertificateById(int id);
        Task<bool> CreateCertificate(Certificate Certificate);
        Task<bool> UpdateCertificate(Certificate Certificate);
        Task<bool> DeleteCertificate(int id);
    }
}

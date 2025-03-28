using BusinessLogicLayer.Services.Interfaces;
using BusinessModels.Entities;
using DataAccessLayer.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class EmployeeService : IEmployeeService
   {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateEmployee(Employee e)
        {
            var result = await _unitOfWork.Employees.AddAsync(e);
            return result;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var result = await _unitOfWork.Employees.DeleteAsync(id);
            return result;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var allEmployees = await _unitOfWork.Employees.GetAllAsync(
                include: query => query
                            .Include(o => o.Certificates)
                                .ThenInclude(c => c.Province)
                            .Include(o => o.Ward)

                               .ThenInclude(od => od.District)
                               .ThenInclude(d => d.Province)

                );
            return allEmployees.FirstOrDefault(e => e.Id == id);
        }
        public async Task<Employee> GetEmployeeByIdentityCard(string id)
        {
            var allEmployees = await _unitOfWork.Employees.GetByDelegateAsync(
                e => e.IdentityCard == id

                );
            return allEmployees.FirstOrDefault();
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _unitOfWork.Employees.GetAllAsync(
                include: query => query
                            .Include(o => o.Certificates)
                            .Include(o => o.Ward)
                                
                               .ThenInclude(od => od.District)
                               .ThenInclude(d => d.Province)
                          
                );
        }

        public async Task<bool> UpdateEmployee(Employee e)
        {
            var result = await _unitOfWork.Employees.UpdateAsync(e);
            return result;
        }
        public async Task<bool> AddRangeEmployee(List<Employee> employees)
        {
            var result = await _unitOfWork.Employees.AddRangeAsync(employees);
            return result;
        }
    }
}

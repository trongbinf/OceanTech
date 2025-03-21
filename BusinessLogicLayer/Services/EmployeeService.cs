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
            return await _unitOfWork.Employees.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _unitOfWork.Employees.GetAllAsync();
        }

        public Task<bool> UpdateEmployee(Employee e)
        {
            var result = _unitOfWork.Employees.UpdateAsync(e);
            return result;
        }
    }
}

using BusinessModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<bool> CreateEmployee(Employee e);
        Task<bool> UpdateEmployee(Employee e);
        Task<bool> DeleteEmployee(int id);
    }
}

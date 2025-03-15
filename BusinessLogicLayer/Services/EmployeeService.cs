using BusinessLogicLayer.Services.Interfaces;
using BusinessModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
   public class EmployeeService : IEmployeeService
    {
        public Task<bool> CreateEmployee(Employee e)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEmployee(Employee e)
        {
            throw new NotImplementedException();
        }
    }
}

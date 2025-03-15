using BusinessModels.Entities;
using DataAccessLayer.Data;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OceanTechDbContext _context;
        public IGenericRepository<Certificate> Certificates { get; }
        public IGenericRepository<District> Districts { get; }
        public IGenericRepository<Employee> Employees { get; }
        public IGenericRepository<Province> Provinces { get; }
        public IGenericRepository<Ward> Wards { get; }

        public UnitOfWork(IGenericRepository<Certificate> certificates, IGenericRepository<District> districts, IGenericRepository<Employee> employees, IGenericRepository<Province> provinces, IGenericRepository<Ward> wards, OceanTechDbContext context)
        {
            _context = context;
            Certificates = certificates;
            Districts = districts;
            Employees = employees;
            Provinces = provinces;
            Wards = wards;
        }

        public Task<int> CompleteAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

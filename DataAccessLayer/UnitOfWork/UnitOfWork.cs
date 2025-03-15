using BusinessModels.Entities;
using DataAccessLayer.Data;
using DataAccessLayer.Repositories;
using System;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly OceanTechDbContext _context;

        public IGenericRepository<Certificate> Certificates { get; private set; }
        public IGenericRepository<District> Districts { get; private set; }
        public IGenericRepository<Employee> Employees { get; private set; }
        public IGenericRepository<Province> Provinces { get; private set; }
        public IGenericRepository<Ward> Wards { get; private set; }

        public UnitOfWork(OceanTechDbContext context)
        {
            _context = context;
            Certificates = new GenericRepository<Certificate>(_context);
            Districts = new GenericRepository<District>(_context);
            Employees = new GenericRepository<Employee>(_context);
            Provinces = new GenericRepository<Province>(_context);
            Wards = new GenericRepository<Ward>(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

using BusinessModels.Entities;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Certificate> Certificates { get; }
        IGenericRepository<District> Districts { get; }
        IGenericRepository<Employee> Employees { get; }
        IGenericRepository<Province> Provinces { get; }
        IGenericRepository<Ward> Wards { get; }
        Task<int> CompleteAsync();

    }
}

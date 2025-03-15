using BusinessModels.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class OceanTechDbContext : DbContext
    {
        public OceanTechDbContext(DbContextOptions<OceanTechDbContext> options) : base(options)
        {
        }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Certificate> Certificates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();

            modelBuilder.Entity<Ward>()
                .HasOne(d => d.District)
                .WithMany(p => p.Wards)
                .HasForeignKey(d => d.DistrictId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<District>()
                .HasOne(d => d.Province)
                .WithMany(p => p.Districts)
                .HasForeignKey(d => d.ProvinceId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Certificate>()
               .HasOne(c => c.Employee)
               .WithMany()
               .HasForeignKey(c => c.EmployeeId)
               .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Certificate>()
                .HasOne(c => c.Province)
                .WithMany()
                .HasForeignKey(c => c.ProvinceId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

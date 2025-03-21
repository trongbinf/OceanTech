using BusinessModels.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Seed Provinces
            modelBuilder.Entity<Province>().HasData(
                new Province { Id = 1, Name = "Hà Nội" },
                new Province { Id = 2, Name = "TP Hồ Chí Minh" }
            );

            // Seed Districts
            modelBuilder.Entity<District>().HasData(
                new District { Id = 1, Name = "Cầu Giấy", ProvinceId = 1 },
                new District { Id = 2, Name = "Tân Bình", ProvinceId = 2 }
            );

            // Seed Wards
            modelBuilder.Entity<Ward>().HasData(
                new Ward { Id = 1, Name = "Dịch Vọng Hậu", DistrictId = 1 },
                new Ward { Id = 2, Name = "Phường 2", DistrictId = 2 }
            );

            // Seed Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FullName = "Nguyen Van A", DateOfBirth = new DateOnly(1990, 5, 10), EthnicGroup = "Kinh", Job = "Kĩ Sư", PhoneNumber = "0123456789", IdentityCard = "123456789", WardId = 1 , Address = "Đường 12"},
                new Employee { Id = 2, FullName = "Tran Thi B", DateOfBirth = new DateOnly(1995, 8, 15), EthnicGroup = "Kinh", Job = "Giáo viên", PhoneNumber = "0987654321", IdentityCard = "987654321", WardId = 2, Address = "Đường 13" }
            );

            // Seed Certificates
            modelBuilder.Entity<Certificate>().HasData(
                new Certificate { Id = 1, Name = "IT Certificate", Description = "Software Engineering", EmployeeId = 1, DateOfIssue = new DateTime(2020, 6, 20), ProvinceId = 1 },
                new Certificate { Id = 2, Name = "Teaching Certificate", Description = "Education", EmployeeId = 2, DateOfIssue = new DateTime(2019, 7, 15), ProvinceId = 2 }
            );
        }
    }
}

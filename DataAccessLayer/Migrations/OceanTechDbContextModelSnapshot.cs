﻿// <auto-generated />
using System;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(OceanTechDbContext))]
    partial class OceanTechDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusinessModels.Entities.Certificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfExpiry")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfIssue")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ProvinceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Certificates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfExpiry = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfIssue = new DateTime(2020, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Software Engineering",
                            EmployeeId = 1,
                            Name = "IT Certificate",
                            ProvinceId = 1
                        },
                        new
                        {
                            Id = 2,
                            DateOfExpiry = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfIssue = new DateTime(2019, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Education",
                            EmployeeId = 2,
                            Name = "Teaching Certificate",
                            ProvinceId = 2
                        });
                });

            modelBuilder.Entity("BusinessModels.Entities.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Districts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cầu Giấy",
                            ProvinceId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tân Bình",
                            ProvinceId = 2
                        });
                });

            modelBuilder.Entity("BusinessModels.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("EthnicGroup")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IdentityCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Job")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("WardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WardId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Đường 12",
                            DateOfBirth = new DateOnly(1990, 5, 10),
                            EthnicGroup = "Kinh",
                            FullName = "Nguyen Van A",
                            IdentityCard = "123456789",
                            Job = "Kĩ Sư",
                            PhoneNumber = "0123456789",
                            WardId = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "Đường 13",
                            DateOfBirth = new DateOnly(1995, 8, 15),
                            EthnicGroup = "Kinh",
                            FullName = "Tran Thi B",
                            IdentityCard = "987654321",
                            Job = "Giáo viên",
                            PhoneNumber = "0987654321",
                            WardId = 2
                        });
                });

            modelBuilder.Entity("BusinessModels.Entities.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Provinces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Hà Nội"
                        },
                        new
                        {
                            Id = 2,
                            Name = "TP Hồ Chí Minh"
                        });
                });

            modelBuilder.Entity("BusinessModels.Entities.Ward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("Wards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DistrictId = 1,
                            Name = "Dịch Vọng Hậu"
                        },
                        new
                        {
                            Id = 2,
                            DistrictId = 2,
                            Name = "Phường 2"
                        });
                });

            modelBuilder.Entity("BusinessModels.Entities.Certificate", b =>
                {
                    b.HasOne("BusinessModels.Entities.Employee", "Employee")
                        .WithMany("Certificates")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessModels.Entities.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Employee");

                    b.Navigation("Province");
                });

            modelBuilder.Entity("BusinessModels.Entities.District", b =>
                {
                    b.HasOne("BusinessModels.Entities.Province", "Province")
                        .WithMany("Districts")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Province");
                });

            modelBuilder.Entity("BusinessModels.Entities.Employee", b =>
                {
                    b.HasOne("BusinessModels.Entities.Ward", "Ward")
                        .WithMany("Employees")
                        .HasForeignKey("WardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ward");
                });

            modelBuilder.Entity("BusinessModels.Entities.Ward", b =>
                {
                    b.HasOne("BusinessModels.Entities.District", "District")
                        .WithMany("Wards")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");
                });

            modelBuilder.Entity("BusinessModels.Entities.District", b =>
                {
                    b.Navigation("Wards");
                });

            modelBuilder.Entity("BusinessModels.Entities.Employee", b =>
                {
                    b.Navigation("Certificates");
                });

            modelBuilder.Entity("BusinessModels.Entities.Province", b =>
                {
                    b.Navigation("Districts");
                });

            modelBuilder.Entity("BusinessModels.Entities.Ward", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}

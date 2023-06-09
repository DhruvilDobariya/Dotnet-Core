﻿// <auto-generated />
using DependencyInjectionLearn.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DependencyInjectionLearn.Domain.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20230508070140_Create EmployeeDB and Employee Table")]
    partial class CreateEmployeeDBandEmployeeTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DependencyInjectionLearn.Domain.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ContactNo")
                        .HasMaxLength(250)
                        .HasColumnType("int");

                    b.Property<int>("Email")
                        .HasMaxLength(250)
                        .HasColumnType("int");

                    b.Property<int>("EmployeeName")
                        .HasMaxLength(250)
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}

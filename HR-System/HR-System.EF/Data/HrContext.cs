using System;
using System.Collections.Generic;
using HR_System.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HR_System.EF.Data
{
    public partial class HrContext : IdentityDbContext
    {
        public HrContext(DbContextOptions<HrContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.HasIndex(e => e.EmployeeId, "EmployeeID");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
                entity.Property(e => e.FilePath).HasMaxLength(255);
                entity.Property(e => e.UploadedDate).HasColumnType("date");

                entity.HasOne(d => d.Employee).WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Attachments_ibfk_1");
            });


            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.DepartmentName).HasMaxLength(100);
            });


            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");


                entity.HasIndex(e => e.DepartmentId, "DepartmentID");
                entity.HasIndex(e => e.Email, "Email").IsUnique();
                entity.HasIndex(e => e.ManagerId, "ManagerID");
                entity.HasIndex(e => e.NationalId, "NationalID").IsUnique();
                entity.HasIndex(e => e.JobId, "JobID");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Address).HasMaxLength(50);
                entity.Property(e => e.DateOfBirth).HasColumnType("date");
                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.Gender).HasMaxLength(50);
                entity.Property(e => e.HireDate).HasColumnType("date");
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
                entity.Property(e => e.NationalId).HasMaxLength(20).HasColumnName("NationalID");
                entity.Property(e => e.Phone).HasMaxLength(15);
                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Employee_ibfk_1");

                entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Employee_ibfk_3");

                entity.HasOne(d => d.Job).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Employee_ibfk_2");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.JobTitle).HasMaxLength(100);
            });

            modelBuilder.Entity<IdentityUser>()
                .Ignore(u => u.PhoneNumber)
                .Ignore(u => u.PhoneNumberConfirmed)
                .Ignore(u => u.TwoFactorEnabled)
                .Ignore(u => u.LockoutEnd)
                .Ignore(u => u.LockoutEnabled)
                .Ignore(u => u.AccessFailedCount);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

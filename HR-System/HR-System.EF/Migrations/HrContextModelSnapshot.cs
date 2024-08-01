﻿// <auto-generated />
using System;
using HR_System.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HR_System.EF.Migrations
{
    [DbContext(typeof(HrContext))]
    partial class HrContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("HR_System.Core.Models.Attachment", b =>
                {
                    b.Property<int>("AttachmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AttachmentID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AttachmentId"));

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    b.Property<string>("FilePath")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("FileType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UploadedDate")
                        .HasColumnType("date");

                    b.HasKey("AttachmentId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "EmployeeId" }, "EmployeeID");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("HR_System.Core.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DepartmentID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("DepartmentId")
                        .HasName("PRIMARY");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("HR_System.Core.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("DepartmentID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Gender")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("date");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int")
                        .HasColumnName("ManagerID");

                    b.Property<string>("NationalId")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("NationalID");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    b.HasKey("EmployeeId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "DepartmentId" }, "DepartmentID");

                    b.HasIndex(new[] { "Email" }, "Email")
                        .IsUnique();

                    b.HasIndex(new[] { "ManagerId" }, "ManagerID");

                    b.HasIndex(new[] { "NationalId" }, "NationalID")
                        .IsUnique();

                    b.HasIndex(new[] { "RoleId" }, "RoleID");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("HR_System.Core.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("RoleId")
                        .HasName("PRIMARY");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("HR_System.Core.Models.User", b =>
                {
                    b.Property<string>("UserName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("UserName")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "EmployeeId" }, "EmployeeID")
                        .HasDatabaseName("EmployeeID1");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("HR_System.Core.Models.Attachment", b =>
                {
                    b.HasOne("HR_System.Core.Models.Employee", "Employee")
                        .WithMany("Attachments")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("Attachments_ibfk_1");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("HR_System.Core.Models.Employee", b =>
                {
                    b.HasOne("HR_System.Core.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("Employee_ibfk_1");

                    b.HasOne("HR_System.Core.Models.Employee", "Manager")
                        .WithMany("InverseManager")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("Employee_ibfk_3");

                    b.HasOne("HR_System.Core.Models.Role", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("Employee_ibfk_2");

                    b.Navigation("Department");

                    b.Navigation("Manager");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HR_System.Core.Models.User", b =>
                {
                    b.HasOne("HR_System.Core.Models.Employee", "Employee")
                        .WithMany("Users")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("User_ibfk_1");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("HR_System.Core.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("HR_System.Core.Models.Employee", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("InverseManager");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("HR_System.Core.Models.Role", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}

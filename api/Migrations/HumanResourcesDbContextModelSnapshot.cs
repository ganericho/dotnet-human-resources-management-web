﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Database;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(HumanResourcesDbContext))]
    partial class HumanResourcesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("api.Account", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("bit")
                        .HasColumnName("is_disabled");

                    b.Property<bool>("IsOtpUsed")
                        .HasColumnType("bit")
                        .HasColumnName("is_otp_used");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<int>("Otp")
                        .HasColumnType("int")
                        .HasColumnName("otp");

                    b.Property<DateTime>("OtpExpireTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("otp_expire_time");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.HasKey("Guid");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("tb_accounts");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"),
                            CreatedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9582),
                            Email = "john.doe@example.com",
                            IsDisabled = false,
                            IsOtpUsed = true,
                            ModifiedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9583),
                            Otp = 123456,
                            OtpExpireTime = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9584),
                            Password = "$2a$12$ICJttvoTd2ixMcIj/Z0xxuITLQwBg8L/IubbXn8O2syCyQchjjA3e"
                        },
                        new
                        {
                            Guid = new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"),
                            CreatedDate = new DateTime(2023, 12, 19, 14, 3, 48, 762, DateTimeKind.Local).AddTicks(5919),
                            Email = "jane.smith@example.com",
                            IsDisabled = false,
                            IsOtpUsed = true,
                            ModifiedDate = new DateTime(2023, 12, 19, 14, 3, 48, 762, DateTimeKind.Local).AddTicks(5920),
                            Otp = 123456,
                            OtpExpireTime = new DateTime(2023, 12, 19, 14, 3, 48, 762, DateTimeKind.Local).AddTicks(5921),
                            Password = "$2a$12$olykDYUaHX7cruD4YYjDQ.8pR8ot7ruNattpO.PMr6KLKkAnYiESy"
                        },
                        new
                        {
                            Guid = new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"),
                            CreatedDate = new DateTime(2023, 12, 19, 14, 3, 49, 60, DateTimeKind.Local).AddTicks(611),
                            Email = "bob.johnson@example.com",
                            IsDisabled = false,
                            IsOtpUsed = true,
                            ModifiedDate = new DateTime(2023, 12, 19, 14, 3, 49, 60, DateTimeKind.Local).AddTicks(611),
                            Otp = 123456,
                            OtpExpireTime = new DateTime(2023, 12, 19, 14, 3, 49, 60, DateTimeKind.Local).AddTicks(612),
                            Password = "$2a$12$y62PzKfkN80FH/sr749nR.UE6UqGbiJA2yeHtNttYDdRseZL7lCe2"
                        });
                });

            modelBuilder.Entity("api.Department", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<Guid?>("ManagerGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("manager_guid");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("name");

                    b.HasKey("Guid");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("ManagerGuid")
                        .IsUnique()
                        .HasFilter("[manager_guid] IS NOT NULL");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("tb_departments");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("7644ad73-57b6-4640-9e8d-f929ba01e694"),
                            Code = "1",
                            CreatedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9351),
                            ModifiedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9356),
                            Name = "Finance"
                        },
                        new
                        {
                            Guid = new Guid("9e0e4c05-cde2-4900-88f9-2a2b8ee0dad6"),
                            Code = "6",
                            CreatedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9358),
                            ModifiedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9359),
                            Name = "Information Technology"
                        },
                        new
                        {
                            Guid = new Guid("e8246140-6e0a-488e-b451-9321b6694736"),
                            Code = "7",
                            CreatedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9361),
                            ModifiedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9361),
                            Name = "Human Resources"
                        });
                });

            modelBuilder.Entity("api.Employee", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birth_date");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<Guid>("DepartmentGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("department_guid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<int>("Gender")
                        .HasColumnType("int")
                        .HasColumnName("gender");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("hiring_date");

                    b.Property<Guid>("JobGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("job_guid");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("phone_number");

                    b.HasKey("Guid");

                    b.HasIndex("DepartmentGuid");

                    b.HasIndex("JobGuid");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("tb_employees");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"),
                            BirthDate = new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9535),
                            DepartmentGuid = new Guid("7644ad73-57b6-4640-9e8d-f929ba01e694"),
                            FirstName = "John",
                            Gender = 1,
                            HiringDate = new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JobGuid = new Guid("1105117d-ed96-4206-bd43-0e13b7342770"),
                            LastName = "Doe",
                            ModifiedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9536),
                            PhoneNumber = "+123456789"
                        },
                        new
                        {
                            Guid = new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"),
                            BirthDate = new DateTime(1985, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9549),
                            DepartmentGuid = new Guid("9e0e4c05-cde2-4900-88f9-2a2b8ee0dad6"),
                            FirstName = "Jane",
                            Gender = 0,
                            HiringDate = new DateTime(2019, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JobGuid = new Guid("25abd2bc-c0fe-411a-ba24-f26cbae523c2"),
                            LastName = "Smith",
                            ModifiedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9549),
                            PhoneNumber = "+987654321"
                        },
                        new
                        {
                            Guid = new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"),
                            BirthDate = new DateTime(1982, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9556),
                            DepartmentGuid = new Guid("e8246140-6e0a-488e-b451-9321b6694736"),
                            FirstName = "Bob",
                            Gender = 1,
                            HiringDate = new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JobGuid = new Guid("a3b9dd56-768a-45f7-99e1-8b42e9c8847f"),
                            LastName = "Johnson",
                            ModifiedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9557),
                            PhoneNumber = "+1122334455"
                        });
                });

            modelBuilder.Entity("api.Job", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<int>("MaxSalary")
                        .HasColumnType("int")
                        .HasColumnName("max_salary");

                    b.Property<int>("MinSalary")
                        .HasColumnType("int")
                        .HasColumnName("min_salary");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Guid");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("tb_jobs");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("1105117d-ed96-4206-bd43-0e13b7342770"),
                            Code = "101",
                            CreatedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9490),
                            MaxSalary = 7500000,
                            MinSalary = 5000000,
                            ModifiedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9490),
                            Name = "Financial Analyst"
                        },
                        new
                        {
                            Guid = new Guid("25abd2bc-c0fe-411a-ba24-f26cbae523c2"),
                            Code = "601",
                            CreatedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9493),
                            MaxSalary = 8000000,
                            MinSalary = 6000000,
                            ModifiedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9494),
                            Name = "Software Developer"
                        },
                        new
                        {
                            Guid = new Guid("a3b9dd56-768a-45f7-99e1-8b42e9c8847f"),
                            Code = "701",
                            CreatedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9496),
                            MaxSalary = 7000000,
                            MinSalary = 5000000,
                            ModifiedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9496),
                            Name = "Recruitment Specialist"
                        });
                });

            modelBuilder.Entity("api.JobHistory", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<Guid>("EmployeeGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("employee_guid");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("end_date");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("is_active");

                    b.Property<Guid>("JobGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("job_guid");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("start_date");

                    b.HasKey("Guid");

                    b.HasIndex("EmployeeGuid");

                    b.HasIndex("JobGuid");

                    b.ToTable("tb_job_histories");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("9c147eec-13c5-4578-8d3e-73718308aef5"),
                            CreatedDate = new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3812),
                            EmployeeGuid = new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"),
                            IsActive = false,
                            JobGuid = new Guid("1105117d-ed96-4206-bd43-0e13b7342770"),
                            ModifiedDate = new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3812),
                            StartDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Guid = new Guid("bbeaafad-6cb2-4b03-ac04-a6babb65c9c8"),
                            CreatedDate = new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3929),
                            EmployeeGuid = new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"),
                            EndDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            JobGuid = new Guid("25abd2bc-c0fe-411a-ba24-f26cbae523c2"),
                            ModifiedDate = new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3930),
                            StartDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Guid = new Guid("c50d9e83-2b81-4c1f-b8ed-742c7fb37b00"),
                            CreatedDate = new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3942),
                            EmployeeGuid = new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"),
                            IsActive = false,
                            JobGuid = new Guid("a3b9dd56-768a-45f7-99e1-8b42e9c8847f"),
                            ModifiedDate = new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3942),
                            StartDate = new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("api.Models.AccountRole", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<Guid>("AccountGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("account_guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<Guid>("RoleGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("role_guid");

                    b.HasKey("Guid");

                    b.HasIndex("AccountGuid");

                    b.HasIndex("RoleGuid");

                    b.ToTable("tb_account_roles");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("f6f14030-7166-4156-92f3-def81475b7f7"),
                            AccountGuid = new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"),
                            CreatedDate = new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3688),
                            ModifiedDate = new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3696),
                            RoleGuid = new Guid("aad98c8c-c71e-46f4-99c1-2d073ecb467f")
                        },
                        new
                        {
                            Guid = new Guid("4c58bae1-1059-4437-8a71-0d38807a7833"),
                            AccountGuid = new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"),
                            CreatedDate = new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3739),
                            ModifiedDate = new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3739),
                            RoleGuid = new Guid("8d1da011-8574-4be4-9f64-657254f764d6")
                        },
                        new
                        {
                            Guid = new Guid("87e4f445-9b4d-4c58-9765-0d14a68900a8"),
                            AccountGuid = new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"),
                            CreatedDate = new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3780),
                            ModifiedDate = new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3781),
                            RoleGuid = new Guid("aca8df20-f7d1-464c-947a-b22bc96c2394")
                        });
                });

            modelBuilder.Entity("api.Role", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("name");

                    b.HasKey("Guid");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("tb_roles");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("aad98c8c-c71e-46f4-99c1-2d073ecb467f"),
                            CreatedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9514),
                            ModifiedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9514),
                            Name = "Staff"
                        },
                        new
                        {
                            Guid = new Guid("8d1da011-8574-4be4-9f64-657254f764d6"),
                            CreatedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9516),
                            ModifiedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9517),
                            Name = "Manager"
                        },
                        new
                        {
                            Guid = new Guid("aca8df20-f7d1-464c-947a-b22bc96c2394"),
                            CreatedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9518),
                            ModifiedDate = new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9519),
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("api.Account", b =>
                {
                    b.HasOne("api.Employee", "Employee")
                        .WithOne("Account")
                        .HasForeignKey("api.Account", "Guid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("api.Department", b =>
                {
                    b.HasOne("api.Employee", "Manager")
                        .WithOne("DepartmentManaged")
                        .HasForeignKey("api.Department", "ManagerGuid")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("api.Employee", b =>
                {
                    b.HasOne("api.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentGuid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("api.Job", "Job")
                        .WithMany("Employees")
                        .HasForeignKey("JobGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("api.JobHistory", b =>
                {
                    b.HasOne("api.Employee", "Employee")
                        .WithMany("JobHistories")
                        .HasForeignKey("EmployeeGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Job", "Job")
                        .WithMany("JobHistories")
                        .HasForeignKey("JobGuid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("api.Models.AccountRole", b =>
                {
                    b.HasOne("api.Account", "Account")
                        .WithMany("AccountRoles")
                        .HasForeignKey("AccountGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Role", "Role")
                        .WithMany("AccountRoles")
                        .HasForeignKey("RoleGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("api.Account", b =>
                {
                    b.Navigation("AccountRoles");
                });

            modelBuilder.Entity("api.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("api.Employee", b =>
                {
                    b.Navigation("Account");

                    b.Navigation("DepartmentManaged");

                    b.Navigation("JobHistories");
                });

            modelBuilder.Entity("api.Job", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("JobHistories");
                });

            modelBuilder.Entity("api.Role", b =>
                {
                    b.Navigation("AccountRoles");
                });
#pragma warning restore 612, 618
        }
    }
}

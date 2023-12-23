using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class SixtDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_account_roles",
                keyColumn: "guid",
                keyValue: new Guid("0b35ce15-2dcb-4949-a38f-9bcecb2a9da3"));

            migrationBuilder.DeleteData(
                table: "tb_account_roles",
                keyColumn: "guid",
                keyValue: new Guid("1b1d4041-b581-4027-b6ce-9ea27b17abb0"));

            migrationBuilder.DeleteData(
                table: "tb_account_roles",
                keyColumn: "guid",
                keyValue: new Guid("9c89d557-8fff-488d-8654-df58146dd17c"));

            migrationBuilder.DeleteData(
                table: "tb_job_histories",
                keyColumn: "guid",
                keyValue: new Guid("12904039-b8b3-48af-9bac-6e99f0d695a3"));

            migrationBuilder.DeleteData(
                table: "tb_job_histories",
                keyColumn: "guid",
                keyValue: new Guid("356c670c-5e4e-421b-9a6b-bd3bf1e28bdc"));

            migrationBuilder.DeleteData(
                table: "tb_job_histories",
                keyColumn: "guid",
                keyValue: new Guid("67934c98-a427-46af-a73b-75497a9522a9"));

            migrationBuilder.DropColumn(
                name: "gender_filter",
                table: "tb_leave_categories");

            migrationBuilder.DropColumn(
                name: "monthly_limit",
                table: "tb_leave_categories");

            migrationBuilder.RenameColumn(
                name: "yearly_limit",
                table: "tb_leave_categories",
                newName: "limit");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "tb_employees",
                newName: "sex");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "tb_leave_records",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "is_female_only",
                table: "tb_leave_categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "nvarchar(20)",
                table: "tb_leave_categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "tb_account_roles",
                columns: new[] { "guid", "account_guid", "created_date", "modified_date", "role_guid" },
                values: new object[,]
                {
                    { new Guid("39aefe6b-7f90-44c8-aae6-4d0d4b026104"), new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"), new DateTime(2023, 12, 23, 10, 57, 0, 819, DateTimeKind.Local).AddTicks(9085), new DateTime(2023, 12, 23, 10, 57, 0, 819, DateTimeKind.Local).AddTicks(9094), new Guid("aad98c8c-c71e-46f4-99c1-2d073ecb467f") },
                    { new Guid("97a11016-efce-4507-8094-92741932bfea"), new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"), new DateTime(2023, 12, 23, 10, 57, 0, 819, DateTimeKind.Local).AddTicks(9213), new DateTime(2023, 12, 23, 10, 57, 0, 819, DateTimeKind.Local).AddTicks(9213), new Guid("aca8df20-f7d1-464c-947a-b22bc96c2394") },
                    { new Guid("db167c27-53a1-4931-8105-9a0ef03075d1"), new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"), new DateTime(2023, 12, 23, 10, 57, 0, 819, DateTimeKind.Local).AddTicks(9164), new DateTime(2023, 12, 23, 10, 57, 0, 819, DateTimeKind.Local).AddTicks(9165), new Guid("8d1da011-8574-4be4-9f64-657254f764d6") }
                });

            migrationBuilder.UpdateData(
                table: "tb_accounts",
                keyColumn: "guid",
                keyValue: new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"),
                columns: new[] { "created_date", "modified_date", "otp_expire_time", "password" },
                values: new object[] { new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8770), new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8771), new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8772), "$2a$12$SvntfiZT2zMC7OEt/R6nwOJ6cWe.R4xRHHuuNp.6dQn11jZyWnEL." });

            migrationBuilder.UpdateData(
                table: "tb_accounts",
                keyColumn: "guid",
                keyValue: new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"),
                columns: new[] { "created_date", "modified_date", "otp_expire_time", "password" },
                values: new object[] { new DateTime(2023, 12, 23, 10, 57, 0, 254, DateTimeKind.Local).AddTicks(9244), new DateTime(2023, 12, 23, 10, 57, 0, 254, DateTimeKind.Local).AddTicks(9244), new DateTime(2023, 12, 23, 10, 57, 0, 254, DateTimeKind.Local).AddTicks(9246), "$2a$12$5a7OKpH/eu/NmbX4.DJVN.NNR0xozfRPGM6AtwNlQf6NYXMwalodK" });

            migrationBuilder.UpdateData(
                table: "tb_accounts",
                keyColumn: "guid",
                keyValue: new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"),
                columns: new[] { "created_date", "modified_date", "otp_expire_time", "password" },
                values: new object[] { new DateTime(2023, 12, 23, 10, 57, 0, 538, DateTimeKind.Local).AddTicks(4772), new DateTime(2023, 12, 23, 10, 57, 0, 538, DateTimeKind.Local).AddTicks(4773), new DateTime(2023, 12, 23, 10, 57, 0, 538, DateTimeKind.Local).AddTicks(4774), "$2a$12$dkdM1EvdFKSpIdFRCJk2POdsJxzck4qgz2Fku1LFGGjNr5LhnRe7e" });

            migrationBuilder.UpdateData(
                table: "tb_departments",
                keyColumn: "guid",
                keyValue: new Guid("7644ad73-57b6-4640-9e8d-f929ba01e694"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8337), new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8347) });

            migrationBuilder.UpdateData(
                table: "tb_departments",
                keyColumn: "guid",
                keyValue: new Guid("9e0e4c05-cde2-4900-88f9-2a2b8ee0dad6"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8351), new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8352) });

            migrationBuilder.UpdateData(
                table: "tb_departments",
                keyColumn: "guid",
                keyValue: new Guid("e8246140-6e0a-488e-b451-9321b6694736"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8380), new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8381) });

            migrationBuilder.UpdateData(
                table: "tb_employees",
                keyColumn: "guid",
                keyValue: new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8701), new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8702) });

            migrationBuilder.UpdateData(
                table: "tb_employees",
                keyColumn: "guid",
                keyValue: new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8716), new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8717) });

            migrationBuilder.UpdateData(
                table: "tb_employees",
                keyColumn: "guid",
                keyValue: new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8727), new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8727) });

            migrationBuilder.InsertData(
                table: "tb_job_histories",
                columns: new[] { "guid", "created_date", "employee_guid", "end_date", "is_active", "job_guid", "modified_date", "start_date" },
                values: new object[,]
                {
                    { new Guid("0ad62c13-4545-4ac1-b5a2-eebf93959301"), new DateTime(2023, 12, 23, 10, 57, 0, 819, DateTimeKind.Local).AddTicks(9266), new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("25abd2bc-c0fe-411a-ba24-f26cbae523c2"), new DateTime(2023, 12, 23, 10, 57, 0, 819, DateTimeKind.Local).AddTicks(9266), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1e810806-3e87-4a3d-86ae-fe7aa8a76b22"), new DateTime(2023, 12, 23, 10, 57, 0, 819, DateTimeKind.Local).AddTicks(9255), new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"), null, false, new Guid("1105117d-ed96-4206-bd43-0e13b7342770"), new DateTime(2023, 12, 23, 10, 57, 0, 819, DateTimeKind.Local).AddTicks(9255), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("25913d0a-e2dd-4b15-9076-67940b0a0bd3"), new DateTime(2023, 12, 23, 10, 57, 0, 819, DateTimeKind.Local).AddTicks(9282), new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"), null, false, new Guid("a3b9dd56-768a-45f7-99e1-8b42e9c8847f"), new DateTime(2023, 12, 23, 10, 57, 0, 819, DateTimeKind.Local).AddTicks(9282), new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "tb_jobs",
                keyColumn: "guid",
                keyValue: new Guid("1105117d-ed96-4206-bd43-0e13b7342770"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8634), new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8635) });

            migrationBuilder.UpdateData(
                table: "tb_jobs",
                keyColumn: "guid",
                keyValue: new Guid("25abd2bc-c0fe-411a-ba24-f26cbae523c2"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8639), new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8639) });

            migrationBuilder.UpdateData(
                table: "tb_jobs",
                keyColumn: "guid",
                keyValue: new Guid("a3b9dd56-768a-45f7-99e1-8b42e9c8847f"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8642), new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8642) });

            migrationBuilder.UpdateData(
                table: "tb_roles",
                keyColumn: "guid",
                keyValue: new Guid("8d1da011-8574-4be4-9f64-657254f764d6"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8673), new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8674) });

            migrationBuilder.UpdateData(
                table: "tb_roles",
                keyColumn: "guid",
                keyValue: new Guid("aad98c8c-c71e-46f4-99c1-2d073ecb467f"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8669), new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8670) });

            migrationBuilder.UpdateData(
                table: "tb_roles",
                keyColumn: "guid",
                keyValue: new Guid("aca8df20-f7d1-464c-947a-b22bc96c2394"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8678), new DateTime(2023, 12, 23, 10, 56, 59, 971, DateTimeKind.Local).AddTicks(8678) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_account_roles",
                keyColumn: "guid",
                keyValue: new Guid("39aefe6b-7f90-44c8-aae6-4d0d4b026104"));

            migrationBuilder.DeleteData(
                table: "tb_account_roles",
                keyColumn: "guid",
                keyValue: new Guid("97a11016-efce-4507-8094-92741932bfea"));

            migrationBuilder.DeleteData(
                table: "tb_account_roles",
                keyColumn: "guid",
                keyValue: new Guid("db167c27-53a1-4931-8105-9a0ef03075d1"));

            migrationBuilder.DeleteData(
                table: "tb_job_histories",
                keyColumn: "guid",
                keyValue: new Guid("0ad62c13-4545-4ac1-b5a2-eebf93959301"));

            migrationBuilder.DeleteData(
                table: "tb_job_histories",
                keyColumn: "guid",
                keyValue: new Guid("1e810806-3e87-4a3d-86ae-fe7aa8a76b22"));

            migrationBuilder.DeleteData(
                table: "tb_job_histories",
                keyColumn: "guid",
                keyValue: new Guid("25913d0a-e2dd-4b15-9076-67940b0a0bd3"));

            migrationBuilder.DropColumn(
                name: "is_female_only",
                table: "tb_leave_categories");

            migrationBuilder.DropColumn(
                name: "nvarchar(20)",
                table: "tb_leave_categories");

            migrationBuilder.RenameColumn(
                name: "limit",
                table: "tb_leave_categories",
                newName: "yearly_limit");

            migrationBuilder.RenameColumn(
                name: "sex",
                table: "tb_employees",
                newName: "gender");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "tb_leave_records",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "gender_filter",
                table: "tb_leave_categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "monthly_limit",
                table: "tb_leave_categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "tb_account_roles",
                columns: new[] { "guid", "account_guid", "created_date", "modified_date", "role_guid" },
                values: new object[,]
                {
                    { new Guid("0b35ce15-2dcb-4949-a38f-9bcecb2a9da3"), new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"), new DateTime(2023, 12, 23, 9, 57, 48, 400, DateTimeKind.Local).AddTicks(97), new DateTime(2023, 12, 23, 9, 57, 48, 400, DateTimeKind.Local).AddTicks(97), new Guid("8d1da011-8574-4be4-9f64-657254f764d6") },
                    { new Guid("1b1d4041-b581-4027-b6ce-9ea27b17abb0"), new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"), new DateTime(2023, 12, 23, 9, 57, 48, 400, DateTimeKind.Local).AddTicks(112), new DateTime(2023, 12, 23, 9, 57, 48, 400, DateTimeKind.Local).AddTicks(113), new Guid("aca8df20-f7d1-464c-947a-b22bc96c2394") },
                    { new Guid("9c89d557-8fff-488d-8654-df58146dd17c"), new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"), new DateTime(2023, 12, 23, 9, 57, 48, 400, DateTimeKind.Local).AddTicks(49), new DateTime(2023, 12, 23, 9, 57, 48, 400, DateTimeKind.Local).AddTicks(55), new Guid("aad98c8c-c71e-46f4-99c1-2d073ecb467f") }
                });

            migrationBuilder.UpdateData(
                table: "tb_accounts",
                keyColumn: "guid",
                keyValue: new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"),
                columns: new[] { "created_date", "modified_date", "otp_expire_time", "password" },
                values: new object[] { new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7844), new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7845), new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7846), "$2a$12$bercSMHZSxL4Cg3lMGaiRepfaXEvEzzTkwF0yNaijqcR0ApUN3nOe" });

            migrationBuilder.UpdateData(
                table: "tb_accounts",
                keyColumn: "guid",
                keyValue: new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"),
                columns: new[] { "created_date", "modified_date", "otp_expire_time", "password" },
                values: new object[] { new DateTime(2023, 12, 23, 9, 57, 47, 834, DateTimeKind.Local).AddTicks(3607), new DateTime(2023, 12, 23, 9, 57, 47, 834, DateTimeKind.Local).AddTicks(3607), new DateTime(2023, 12, 23, 9, 57, 47, 834, DateTimeKind.Local).AddTicks(3609), "$2a$12$l58xzAB961p4fqE2IrxgrOoTTFW0tUCmrhcvRDHV888rjRTzZNale" });

            migrationBuilder.UpdateData(
                table: "tb_accounts",
                keyColumn: "guid",
                keyValue: new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"),
                columns: new[] { "created_date", "modified_date", "otp_expire_time", "password" },
                values: new object[] { new DateTime(2023, 12, 23, 9, 57, 48, 120, DateTimeKind.Local).AddTicks(692), new DateTime(2023, 12, 23, 9, 57, 48, 120, DateTimeKind.Local).AddTicks(693), new DateTime(2023, 12, 23, 9, 57, 48, 120, DateTimeKind.Local).AddTicks(694), "$2a$12$loBXUDagyyo3e26Agz8QxOw11nv76PsMuO.Kxr9IxbkcG4xGdWOde" });

            migrationBuilder.UpdateData(
                table: "tb_departments",
                keyColumn: "guid",
                keyValue: new Guid("7644ad73-57b6-4640-9e8d-f929ba01e694"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7491), new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7499) });

            migrationBuilder.UpdateData(
                table: "tb_departments",
                keyColumn: "guid",
                keyValue: new Guid("9e0e4c05-cde2-4900-88f9-2a2b8ee0dad6"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7503), new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7503) });

            migrationBuilder.UpdateData(
                table: "tb_departments",
                keyColumn: "guid",
                keyValue: new Guid("e8246140-6e0a-488e-b451-9321b6694736"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7519), new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7520) });

            migrationBuilder.UpdateData(
                table: "tb_employees",
                keyColumn: "guid",
                keyValue: new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7796), new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7796) });

            migrationBuilder.UpdateData(
                table: "tb_employees",
                keyColumn: "guid",
                keyValue: new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7807), new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7808) });

            migrationBuilder.UpdateData(
                table: "tb_employees",
                keyColumn: "guid",
                keyValue: new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7814), new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7815) });

            migrationBuilder.InsertData(
                table: "tb_job_histories",
                columns: new[] { "guid", "created_date", "employee_guid", "end_date", "is_active", "job_guid", "modified_date", "start_date" },
                values: new object[,]
                {
                    { new Guid("12904039-b8b3-48af-9bac-6e99f0d695a3"), new DateTime(2023, 12, 23, 9, 57, 48, 400, DateTimeKind.Local).AddTicks(155), new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("25abd2bc-c0fe-411a-ba24-f26cbae523c2"), new DateTime(2023, 12, 23, 9, 57, 48, 400, DateTimeKind.Local).AddTicks(156), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("356c670c-5e4e-421b-9a6b-bd3bf1e28bdc"), new DateTime(2023, 12, 23, 9, 57, 48, 400, DateTimeKind.Local).AddTicks(179), new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"), null, false, new Guid("a3b9dd56-768a-45f7-99e1-8b42e9c8847f"), new DateTime(2023, 12, 23, 9, 57, 48, 400, DateTimeKind.Local).AddTicks(180), new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("67934c98-a427-46af-a73b-75497a9522a9"), new DateTime(2023, 12, 23, 9, 57, 48, 400, DateTimeKind.Local).AddTicks(145), new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"), null, false, new Guid("1105117d-ed96-4206-bd43-0e13b7342770"), new DateTime(2023, 12, 23, 9, 57, 48, 400, DateTimeKind.Local).AddTicks(146), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "tb_jobs",
                keyColumn: "guid",
                keyValue: new Guid("1105117d-ed96-4206-bd43-0e13b7342770"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7709), new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7710) });

            migrationBuilder.UpdateData(
                table: "tb_jobs",
                keyColumn: "guid",
                keyValue: new Guid("25abd2bc-c0fe-411a-ba24-f26cbae523c2"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7713), new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7713) });

            migrationBuilder.UpdateData(
                table: "tb_jobs",
                keyColumn: "guid",
                keyValue: new Guid("a3b9dd56-768a-45f7-99e1-8b42e9c8847f"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7716), new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7716) });

            migrationBuilder.UpdateData(
                table: "tb_roles",
                keyColumn: "guid",
                keyValue: new Guid("8d1da011-8574-4be4-9f64-657254f764d6"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7777), new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7778) });

            migrationBuilder.UpdateData(
                table: "tb_roles",
                keyColumn: "guid",
                keyValue: new Guid("aad98c8c-c71e-46f4-99c1-2d073ecb467f"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7774), new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7775) });

            migrationBuilder.UpdateData(
                table: "tb_roles",
                keyColumn: "guid",
                keyValue: new Guid("aca8df20-f7d1-464c-947a-b22bc96c2394"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7780), new DateTime(2023, 12, 23, 9, 57, 47, 542, DateTimeKind.Local).AddTicks(7781) });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class FifthDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_account_roles",
                keyColumn: "guid",
                keyValue: new Guid("4c58bae1-1059-4437-8a71-0d38807a7833"));

            migrationBuilder.DeleteData(
                table: "tb_account_roles",
                keyColumn: "guid",
                keyValue: new Guid("87e4f445-9b4d-4c58-9765-0d14a68900a8"));

            migrationBuilder.DeleteData(
                table: "tb_account_roles",
                keyColumn: "guid",
                keyValue: new Guid("f6f14030-7166-4156-92f3-def81475b7f7"));

            migrationBuilder.DeleteData(
                table: "tb_job_histories",
                keyColumn: "guid",
                keyValue: new Guid("9c147eec-13c5-4578-8d3e-73718308aef5"));

            migrationBuilder.DeleteData(
                table: "tb_job_histories",
                keyColumn: "guid",
                keyValue: new Guid("bbeaafad-6cb2-4b03-ac04-a6babb65c9c8"));

            migrationBuilder.DeleteData(
                table: "tb_job_histories",
                keyColumn: "guid",
                keyValue: new Guid("c50d9e83-2b81-4c1f-b8ed-742c7fb37b00"));

            migrationBuilder.CreateTable(
                name: "tb_leave_categories",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    min_duration = table.Column<int>(type: "int", nullable: false),
                    max_duration = table.Column<int>(type: "int", nullable: false),
                    gender_filter = table.Column<int>(type: "int", nullable: false),
                    yearly_limit = table.Column<int>(type: "int", nullable: false),
                    monthly_limit = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_leave_categories", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "tb_leave_records",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    leave_category_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    employee_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    user_remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    admin_remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_leave_records", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_leave_records_tb_employees_employee_guid",
                        column: x => x.employee_guid,
                        principalTable: "tb_employees",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_leave_records_tb_leave_categories_leave_category_guid",
                        column: x => x.leave_category_guid,
                        principalTable: "tb_leave_categories",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_tb_leave_categories_name",
                table: "tb_leave_categories",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_leave_records_employee_guid",
                table: "tb_leave_records",
                column: "employee_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_leave_records_leave_category_guid",
                table: "tb_leave_records",
                column: "leave_category_guid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_leave_records");

            migrationBuilder.DropTable(
                name: "tb_leave_categories");

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

            migrationBuilder.InsertData(
                table: "tb_account_roles",
                columns: new[] { "guid", "account_guid", "created_date", "modified_date", "role_guid" },
                values: new object[,]
                {
                    { new Guid("4c58bae1-1059-4437-8a71-0d38807a7833"), new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"), new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3739), new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3739), new Guid("8d1da011-8574-4be4-9f64-657254f764d6") },
                    { new Guid("87e4f445-9b4d-4c58-9765-0d14a68900a8"), new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"), new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3780), new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3781), new Guid("aca8df20-f7d1-464c-947a-b22bc96c2394") },
                    { new Guid("f6f14030-7166-4156-92f3-def81475b7f7"), new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"), new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3688), new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3696), new Guid("aad98c8c-c71e-46f4-99c1-2d073ecb467f") }
                });

            migrationBuilder.UpdateData(
                table: "tb_accounts",
                keyColumn: "guid",
                keyValue: new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"),
                columns: new[] { "created_date", "modified_date", "otp_expire_time", "password" },
                values: new object[] { new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9582), new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9583), new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9584), "$2a$12$ICJttvoTd2ixMcIj/Z0xxuITLQwBg8L/IubbXn8O2syCyQchjjA3e" });

            migrationBuilder.UpdateData(
                table: "tb_accounts",
                keyColumn: "guid",
                keyValue: new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"),
                columns: new[] { "created_date", "modified_date", "otp_expire_time", "password" },
                values: new object[] { new DateTime(2023, 12, 19, 14, 3, 48, 762, DateTimeKind.Local).AddTicks(5919), new DateTime(2023, 12, 19, 14, 3, 48, 762, DateTimeKind.Local).AddTicks(5920), new DateTime(2023, 12, 19, 14, 3, 48, 762, DateTimeKind.Local).AddTicks(5921), "$2a$12$olykDYUaHX7cruD4YYjDQ.8pR8ot7ruNattpO.PMr6KLKkAnYiESy" });

            migrationBuilder.UpdateData(
                table: "tb_accounts",
                keyColumn: "guid",
                keyValue: new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"),
                columns: new[] { "created_date", "modified_date", "otp_expire_time", "password" },
                values: new object[] { new DateTime(2023, 12, 19, 14, 3, 49, 60, DateTimeKind.Local).AddTicks(611), new DateTime(2023, 12, 19, 14, 3, 49, 60, DateTimeKind.Local).AddTicks(611), new DateTime(2023, 12, 19, 14, 3, 49, 60, DateTimeKind.Local).AddTicks(612), "$2a$12$y62PzKfkN80FH/sr749nR.UE6UqGbiJA2yeHtNttYDdRseZL7lCe2" });

            migrationBuilder.UpdateData(
                table: "tb_departments",
                keyColumn: "guid",
                keyValue: new Guid("7644ad73-57b6-4640-9e8d-f929ba01e694"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9351), new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9356) });

            migrationBuilder.UpdateData(
                table: "tb_departments",
                keyColumn: "guid",
                keyValue: new Guid("9e0e4c05-cde2-4900-88f9-2a2b8ee0dad6"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9358), new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9359) });

            migrationBuilder.UpdateData(
                table: "tb_departments",
                keyColumn: "guid",
                keyValue: new Guid("e8246140-6e0a-488e-b451-9321b6694736"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9361), new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9361) });

            migrationBuilder.UpdateData(
                table: "tb_employees",
                keyColumn: "guid",
                keyValue: new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9535), new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9536) });

            migrationBuilder.UpdateData(
                table: "tb_employees",
                keyColumn: "guid",
                keyValue: new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9549), new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9549) });

            migrationBuilder.UpdateData(
                table: "tb_employees",
                keyColumn: "guid",
                keyValue: new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9556), new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9557) });

            migrationBuilder.InsertData(
                table: "tb_job_histories",
                columns: new[] { "guid", "created_date", "employee_guid", "end_date", "is_active", "job_guid", "modified_date", "start_date" },
                values: new object[,]
                {
                    { new Guid("9c147eec-13c5-4578-8d3e-73718308aef5"), new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3812), new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"), null, false, new Guid("1105117d-ed96-4206-bd43-0e13b7342770"), new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3812), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bbeaafad-6cb2-4b03-ac04-a6babb65c9c8"), new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3929), new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("25abd2bc-c0fe-411a-ba24-f26cbae523c2"), new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3930), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c50d9e83-2b81-4c1f-b8ed-742c7fb37b00"), new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3942), new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"), null, false, new Guid("a3b9dd56-768a-45f7-99e1-8b42e9c8847f"), new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3942), new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "tb_jobs",
                keyColumn: "guid",
                keyValue: new Guid("1105117d-ed96-4206-bd43-0e13b7342770"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9490), new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9490) });

            migrationBuilder.UpdateData(
                table: "tb_jobs",
                keyColumn: "guid",
                keyValue: new Guid("25abd2bc-c0fe-411a-ba24-f26cbae523c2"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9493), new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9494) });

            migrationBuilder.UpdateData(
                table: "tb_jobs",
                keyColumn: "guid",
                keyValue: new Guid("a3b9dd56-768a-45f7-99e1-8b42e9c8847f"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9496), new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9496) });

            migrationBuilder.UpdateData(
                table: "tb_roles",
                keyColumn: "guid",
                keyValue: new Guid("8d1da011-8574-4be4-9f64-657254f764d6"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9516), new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9517) });

            migrationBuilder.UpdateData(
                table: "tb_roles",
                keyColumn: "guid",
                keyValue: new Guid("aad98c8c-c71e-46f4-99c1-2d073ecb467f"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9514), new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9514) });

            migrationBuilder.UpdateData(
                table: "tb_roles",
                keyColumn: "guid",
                keyValue: new Guid("aca8df20-f7d1-464c-947a-b22bc96c2394"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9518), new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9519) });
        }
    }
}

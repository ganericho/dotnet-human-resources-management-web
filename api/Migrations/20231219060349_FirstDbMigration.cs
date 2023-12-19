using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class FirstDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_jobs",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    min_salary = table.Column<int>(type: "int", nullable: false),
                    max_salary = table.Column<int>(type: "int", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_jobs", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "tb_roles",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_roles", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "tb_account_roles",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    account_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    role_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_account_roles", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_account_roles_tb_roles_role_guid",
                        column: x => x.role_guid,
                        principalTable: "tb_roles",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_accounts",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_disabled = table.Column<bool>(type: "bit", nullable: false),
                    otp = table.Column<int>(type: "int", nullable: false),
                    is_otp_used = table.Column<bool>(type: "bit", nullable: false),
                    otp_expire_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_accounts", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "tb_departments",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(2)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    manager_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_departments", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "tb_employees",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hiring_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    department_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    job_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_employees", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_employees_tb_departments_department_guid",
                        column: x => x.department_guid,
                        principalTable: "tb_departments",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_employees_tb_jobs_job_guid",
                        column: x => x.job_guid,
                        principalTable: "tb_jobs",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_job_histories",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    employee_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    job_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_job_histories", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_job_histories_tb_employees_employee_guid",
                        column: x => x.employee_guid,
                        principalTable: "tb_employees",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_job_histories_tb_jobs_job_guid",
                        column: x => x.job_guid,
                        principalTable: "tb_jobs",
                        principalColumn: "guid");
                });

            migrationBuilder.InsertData(
                table: "tb_departments",
                columns: new[] { "guid", "code", "created_date", "manager_guid", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("7644ad73-57b6-4640-9e8d-f929ba01e694"), "1", new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9351), null, new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9356), "Finance" },
                    { new Guid("9e0e4c05-cde2-4900-88f9-2a2b8ee0dad6"), "6", new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9358), null, new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9359), "Information Technology" },
                    { new Guid("e8246140-6e0a-488e-b451-9321b6694736"), "7", new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9361), null, new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9361), "Human Resources" }
                });

            migrationBuilder.InsertData(
                table: "tb_jobs",
                columns: new[] { "guid", "code", "created_date", "max_salary", "min_salary", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("1105117d-ed96-4206-bd43-0e13b7342770"), "101", new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9490), 7500000, 5000000, new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9490), "Financial Analyst" },
                    { new Guid("25abd2bc-c0fe-411a-ba24-f26cbae523c2"), "601", new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9493), 8000000, 6000000, new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9494), "Software Developer" },
                    { new Guid("a3b9dd56-768a-45f7-99e1-8b42e9c8847f"), "701", new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9496), 7000000, 5000000, new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9496), "Recruitment Specialist" }
                });

            migrationBuilder.InsertData(
                table: "tb_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("8d1da011-8574-4be4-9f64-657254f764d6"), new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9516), new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9517), "Manager" },
                    { new Guid("aad98c8c-c71e-46f4-99c1-2d073ecb467f"), new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9514), new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9514), "Staff" },
                    { new Guid("aca8df20-f7d1-464c-947a-b22bc96c2394"), new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9518), new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9519), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "tb_employees",
                columns: new[] { "guid", "birth_date", "created_date", "department_guid", "first_name", "gender", "hiring_date", "job_guid", "last_name", "modified_date", "phone_number" },
                values: new object[] { new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"), new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9535), new Guid("7644ad73-57b6-4640-9e8d-f929ba01e694"), "John", 1, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1105117d-ed96-4206-bd43-0e13b7342770"), "Doe", new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9536), "+123456789" });

            migrationBuilder.InsertData(
                table: "tb_employees",
                columns: new[] { "guid", "birth_date", "created_date", "department_guid", "first_name", "gender", "hiring_date", "job_guid", "last_name", "modified_date", "phone_number" },
                values: new object[] { new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"), new DateTime(1985, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9549), new Guid("9e0e4c05-cde2-4900-88f9-2a2b8ee0dad6"), "Jane", 0, new DateTime(2019, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("25abd2bc-c0fe-411a-ba24-f26cbae523c2"), "Smith", new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9549), "+987654321" });

            migrationBuilder.InsertData(
                table: "tb_employees",
                columns: new[] { "guid", "birth_date", "created_date", "department_guid", "first_name", "gender", "hiring_date", "job_guid", "last_name", "modified_date", "phone_number" },
                values: new object[] { new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"), new DateTime(1982, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9556), new Guid("e8246140-6e0a-488e-b451-9321b6694736"), "Bob", 1, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a3b9dd56-768a-45f7-99e1-8b42e9c8847f"), "Johnson", new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9557), "+1122334455" });

            migrationBuilder.InsertData(
                table: "tb_accounts",
                columns: new[] { "guid", "created_date", "email", "is_disabled", "is_otp_used", "modified_date", "otp", "otp_expire_time", "password" },
                values: new object[,]
                {
                    { new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"), new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9582), "john.doe@example.com", false, true, new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9583), 123456, new DateTime(2023, 12, 19, 14, 3, 48, 465, DateTimeKind.Local).AddTicks(9584), "$2a$12$ICJttvoTd2ixMcIj/Z0xxuITLQwBg8L/IubbXn8O2syCyQchjjA3e" },
                    { new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"), new DateTime(2023, 12, 19, 14, 3, 48, 762, DateTimeKind.Local).AddTicks(5919), "jane.smith@example.com", false, true, new DateTime(2023, 12, 19, 14, 3, 48, 762, DateTimeKind.Local).AddTicks(5920), 123456, new DateTime(2023, 12, 19, 14, 3, 48, 762, DateTimeKind.Local).AddTicks(5921), "$2a$12$olykDYUaHX7cruD4YYjDQ.8pR8ot7ruNattpO.PMr6KLKkAnYiESy" },
                    { new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"), new DateTime(2023, 12, 19, 14, 3, 49, 60, DateTimeKind.Local).AddTicks(611), "bob.johnson@example.com", false, true, new DateTime(2023, 12, 19, 14, 3, 49, 60, DateTimeKind.Local).AddTicks(611), 123456, new DateTime(2023, 12, 19, 14, 3, 49, 60, DateTimeKind.Local).AddTicks(612), "$2a$12$y62PzKfkN80FH/sr749nR.UE6UqGbiJA2yeHtNttYDdRseZL7lCe2" }
                });

            migrationBuilder.InsertData(
                table: "tb_job_histories",
                columns: new[] { "guid", "created_date", "employee_guid", "end_date", "is_active", "job_guid", "modified_date", "start_date" },
                values: new object[,]
                {
                    { new Guid("9c147eec-13c5-4578-8d3e-73718308aef5"), new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3812), new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"), null, false, new Guid("1105117d-ed96-4206-bd43-0e13b7342770"), new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3812), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bbeaafad-6cb2-4b03-ac04-a6babb65c9c8"), new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3929), new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("25abd2bc-c0fe-411a-ba24-f26cbae523c2"), new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3930), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c50d9e83-2b81-4c1f-b8ed-742c7fb37b00"), new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3942), new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"), null, false, new Guid("a3b9dd56-768a-45f7-99e1-8b42e9c8847f"), new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3942), new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tb_account_roles",
                columns: new[] { "guid", "account_guid", "created_date", "modified_date", "role_guid" },
                values: new object[] { new Guid("4c58bae1-1059-4437-8a71-0d38807a7833"), new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"), new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3739), new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3739), new Guid("8d1da011-8574-4be4-9f64-657254f764d6") });

            migrationBuilder.InsertData(
                table: "tb_account_roles",
                columns: new[] { "guid", "account_guid", "created_date", "modified_date", "role_guid" },
                values: new object[] { new Guid("87e4f445-9b4d-4c58-9765-0d14a68900a8"), new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"), new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3780), new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3781), new Guid("aca8df20-f7d1-464c-947a-b22bc96c2394") });

            migrationBuilder.InsertData(
                table: "tb_account_roles",
                columns: new[] { "guid", "account_guid", "created_date", "modified_date", "role_guid" },
                values: new object[] { new Guid("f6f14030-7166-4156-92f3-def81475b7f7"), new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"), new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3688), new DateTime(2023, 12, 19, 14, 3, 49, 347, DateTimeKind.Local).AddTicks(3696), new Guid("aad98c8c-c71e-46f4-99c1-2d073ecb467f") });

            migrationBuilder.CreateIndex(
                name: "IX_tb_account_roles_account_guid",
                table: "tb_account_roles",
                column: "account_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_account_roles_role_guid",
                table: "tb_account_roles",
                column: "role_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_accounts_email",
                table: "tb_accounts",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_departments_code",
                table: "tb_departments",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_departments_manager_guid",
                table: "tb_departments",
                column: "manager_guid",
                unique: true,
                filter: "[manager_guid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tb_departments_name",
                table: "tb_departments",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_employees_department_guid",
                table: "tb_employees",
                column: "department_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_employees_job_guid",
                table: "tb_employees",
                column: "job_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_employees_phone_number",
                table: "tb_employees",
                column: "phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_job_histories_employee_guid",
                table: "tb_job_histories",
                column: "employee_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_job_histories_job_guid",
                table: "tb_job_histories",
                column: "job_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_jobs_code",
                table: "tb_jobs",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_jobs_name",
                table: "tb_jobs",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_roles_name",
                table: "tb_roles",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_account_roles_tb_accounts_account_guid",
                table: "tb_account_roles",
                column: "account_guid",
                principalTable: "tb_accounts",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_accounts_tb_employees_guid",
                table: "tb_accounts",
                column: "guid",
                principalTable: "tb_employees",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_departments_tb_employees_manager_guid",
                table: "tb_departments",
                column: "manager_guid",
                principalTable: "tb_employees",
                principalColumn: "guid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_departments_tb_employees_manager_guid",
                table: "tb_departments");

            migrationBuilder.DropTable(
                name: "tb_account_roles");

            migrationBuilder.DropTable(
                name: "tb_job_histories");

            migrationBuilder.DropTable(
                name: "tb_accounts");

            migrationBuilder.DropTable(
                name: "tb_roles");

            migrationBuilder.DropTable(
                name: "tb_employees");

            migrationBuilder.DropTable(
                name: "tb_departments");

            migrationBuilder.DropTable(
                name: "tb_jobs");
        }
    }
}

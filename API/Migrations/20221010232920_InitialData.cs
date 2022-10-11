using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AuditPlans",
                columns: new[] { "Id", "CommentPageId", "Description", "Title" },
                values: new object[] { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), null, "Second plan description", "Second plan" });

            migrationBuilder.InsertData(
                table: "AuditPlans",
                columns: new[] { "Id", "CommentPageId", "Description", "Title" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), null, "First plan description", "First plan" });

            migrationBuilder.InsertData(
                table: "Audits",
                columns: new[] { "Id", "AuditPlanId", "CommentPageId", "Description", "StartDate", "State", "Title" },
                values: new object[] { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), null, "First audit description", new DateTime(2022, 10, 10, 18, 29, 20, 751, DateTimeKind.Local).AddTicks(2441), 0, "First audit" });

            migrationBuilder.InsertData(
                table: "Audits",
                columns: new[] { "Id", "AuditPlanId", "CommentPageId", "Description", "StartDate", "State", "Title" },
                values: new object[] { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), null, "Second audit description", new DateTime(2022, 10, 10, 18, 29, 20, 751, DateTimeKind.Local).AddTicks(2454), 0, "Second audit" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Audits",
                keyColumn: "Id",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "Audits",
                keyColumn: "Id",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"));

            migrationBuilder.DeleteData(
                table: "AuditPlans",
                keyColumn: "Id",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "AuditPlans",
                keyColumn: "Id",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));
        }
    }
}

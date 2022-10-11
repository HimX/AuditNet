using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CommentPageId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditPlans_CommentPages_CommentPageId",
                        column: x => x.CommentPageId,
                        principalTable: "CommentPages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    State = table.Column<int>(type: "INTEGER", nullable: true),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    CommentPageId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_CommentPages_CommentPageId",
                        column: x => x.CommentPageId,
                        principalTable: "CommentPages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    State = table.Column<int>(type: "INTEGER", nullable: false),
                    AuditPlanId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CommentPageId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Audits_AuditPlans_AuditPlanId",
                        column: x => x.AuditPlanId,
                        principalTable: "AuditPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Audits_CommentPages_CommentPageId",
                        column: x => x.CommentPageId,
                        principalTable: "CommentPages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AuditPerson",
                columns: table => new
                {
                    AuditId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PersonId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditPerson", x => new { x.AuditId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_AuditPerson_Audits_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditPerson_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CommentPageId = table.Column<Guid>(type: "TEXT", nullable: true),
                    AuditId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Audits_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Schedules_CommentPages_CommentPageId",
                        column: x => x.CommentPageId,
                        principalTable: "CommentPages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditPerson_AuditId_PersonId",
                table: "AuditPerson",
                columns: new[] { "AuditId", "PersonId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuditPerson_PersonId",
                table: "AuditPerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditPlans_CommentPageId",
                table: "AuditPlans",
                column: "CommentPageId");

            migrationBuilder.CreateIndex(
                name: "IX_Audits_AuditPlanId",
                table: "Audits",
                column: "AuditPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Audits_CommentPageId",
                table: "Audits",
                column: "CommentPageId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentPageId",
                table: "Comments",
                column: "CommentPageId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_AuditId",
                table: "Schedules",
                column: "AuditId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_CommentPageId",
                table: "Schedules",
                column: "CommentPageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditPerson");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropTable(
                name: "AuditPlans");

            migrationBuilder.DropTable(
                name: "CommentPages");
        }
    }
}

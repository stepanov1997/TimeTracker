using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeTracker.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Clients",
                table => new
                {
                    Id = table.Column<long>()
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>()
                },
                constraints: table => { table.PrimaryKey("PK_Clients", x => x.Id); });

            migrationBuilder.CreateTable(
                "Users",
                table => new
                {
                    Id = table.Column<long>()
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(),
                    HourRate = table.Column<decimal>()
                },
                constraints: table => { table.PrimaryKey("PK_Users", x => x.Id); });

            migrationBuilder.CreateTable(
                "Projects",
                table => new
                {
                    Id = table.Column<long>()
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(),
                    ClientId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        "FK_Projects_Clients_ClientId",
                        x => x.ClientId,
                        "Clients",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "TimeEntries",
                table => new
                {
                    Id = table.Column<long>()
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectId = table.Column<long>(),
                    EntryDate = table.Column<DateTime>(),
                    Hours = table.Column<int>(),
                    Description = table.Column<string>(),
                    HourRate = table.Column<decimal>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeEntries", x => x.Id);
                    table.ForeignKey(
                        "FK_TimeEntries_Projects_ProjectId",
                        x => x.ProjectId,
                        "Projects",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Projects_ClientId",
                "Projects",
                "ClientId");

            migrationBuilder.CreateIndex(
                "IX_TimeEntries_ProjectId",
                "TimeEntries",
                "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "TimeEntries");

            migrationBuilder.DropTable(
                "Users");

            migrationBuilder.DropTable(
                "Projects");

            migrationBuilder.DropTable(
                "Clients");
        }
    }
}
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeTracker.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                "Clients",
                new[] {"Id", "Name"},
                new object[] {1L, "Client 1"});

            migrationBuilder.InsertData(
                "Clients",
                new[] {"Id", "Name"},
                new object[] {2L, "Client 2"});

            migrationBuilder.InsertData(
                "Projects",
                new[] {"Id", "ClientId", "Name"},
                new object[] {3L, 2L, "Project 3"});

            migrationBuilder.InsertData(
                "Users",
                new[] {"Id", "HourRate", "Name"},
                new object[] {1L, 15m, "User 1"});

            migrationBuilder.InsertData(
                "Users",
                new[] {"Id", "HourRate", "Name"},
                new object[] {2L, 10m, "User 2"});

            migrationBuilder.InsertData(
                "Projects",
                new[] {"Id", "ClientId", "Name"},
                new object[] {1L, 1L, "Project 1"});

            migrationBuilder.InsertData(
                "Projects",
                new[] {"Id", "ClientId", "Name"},
                new object[] {2L, 1L, "Project 2"});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                "Projects",
                "Id",
                1L);

            migrationBuilder.DeleteData(
                "Projects",
                "Id",
                2L);

            migrationBuilder.DeleteData(
                "Projects",
                "Id",
                3L);

            migrationBuilder.DeleteData(
                "Users",
                "Id",
                1L);

            migrationBuilder.DeleteData(
                "Users",
                "Id",
                2L);

            migrationBuilder.DeleteData(
                "Clients",
                "Id",
                1L);

            migrationBuilder.DeleteData(
                "Clients",
                "Id",
                2L);
        }
    }
}
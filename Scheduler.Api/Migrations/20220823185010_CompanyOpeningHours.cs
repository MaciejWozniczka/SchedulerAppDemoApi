using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scheduler.Api.Migrations
{
    public partial class CompanyOpeningHours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosingTime",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "DayOfTheWeek",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "OpeningTime",
                table: "Companies");

            migrationBuilder.CreateTable(
                name: "CompaniesOpeningHours",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayOfTheWeek = table.Column<int>(type: "int", nullable: false),
                    OpeningTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosingTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompaniesOpeningHours", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompaniesOpeningHours");

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosingTime",
                table: "Companies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DayOfTheWeek",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpeningTime",
                table: "Companies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

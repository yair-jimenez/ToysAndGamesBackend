using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ignoreReferencialObj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Addres = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastModification = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AgeRestriction = table.Column<int>(type: "int", precision: 3, nullable: false, defaultValue: 0),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    LastModification = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Addres", "LastModification", "Name" },
                values: new object[] { 1, "", new DateTime(2021, 9, 10, 22, 29, 11, 738, DateTimeKind.Local).AddTicks(1261), "Mattel" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AgeRestriction", "CompanyId", "Description", "LastModification", "Name", "Price", "UrlImage" },
                values: new object[] { 1, 5, 1, "Racing Model 1991", new DateTime(2021, 9, 10, 22, 29, 11, 721, DateTimeKind.Local).AddTicks(4052), "HotWheels Model 1", 10.50m, "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AgeRestriction", "CompanyId", "Description", "LastModification", "Name", "Price", "UrlImage" },
                values: new object[] { 2, 3, 1, "Racing Model 1991", new DateTime(2021, 9, 10, 22, 29, 11, 724, DateTimeKind.Local).AddTicks(3173), "HotWheels Model 2", 100.50m, "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AgeRestriction", "CompanyId", "Description", "LastModification", "Name", "Price", "UrlImage" },
                values: new object[] { 3, 3, 1, "Racing Model 1992", new DateTime(2021, 9, 10, 22, 29, 11, 724, DateTimeKind.Local).AddTicks(3216), "HotWheels Model 3", 69.50m, "" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId",
                table: "Products",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}

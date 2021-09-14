using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class imageContainer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModification",
                value: new DateTime(2021, 9, 14, 9, 12, 45, 688, DateTimeKind.Local).AddTicks(940));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModification",
                value: new DateTime(2021, 9, 14, 9, 12, 45, 680, DateTimeKind.Local).AddTicks(1526));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModification",
                value: new DateTime(2021, 9, 14, 9, 12, 45, 682, DateTimeKind.Local).AddTicks(3263));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModification",
                value: new DateTime(2021, 9, 14, 9, 12, 45, 682, DateTimeKind.Local).AddTicks(3293));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModification",
                value: new DateTime(2021, 9, 10, 22, 29, 11, 738, DateTimeKind.Local).AddTicks(1261));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModification",
                value: new DateTime(2021, 9, 10, 22, 29, 11, 721, DateTimeKind.Local).AddTicks(4052));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModification",
                value: new DateTime(2021, 9, 10, 22, 29, 11, 724, DateTimeKind.Local).AddTicks(3173));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastModification",
                value: new DateTime(2021, 9, 10, 22, 29, 11, 724, DateTimeKind.Local).AddTicks(3216));
        }
    }
}

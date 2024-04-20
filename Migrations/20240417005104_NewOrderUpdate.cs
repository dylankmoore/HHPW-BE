using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HHPW_BE.Migrations
{
    public partial class NewOrderUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                columns: new[] { "CloseTime", "IsOpen" },
                values: new object[] { null, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                columns: new[] { "CloseTime", "IsOpen" },
                values: new object[] { new DateTime(2024, 4, 3, 6, 0, 0, 0, DateTimeKind.Unspecified), false });
        }
    }
}

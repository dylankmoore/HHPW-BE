using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HHPW_BE.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirebaseKey",
                table: "Users",
                newName: "Uid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Uid",
                table: "Users",
                newName: "FirebaseKey");
        }
    }
}

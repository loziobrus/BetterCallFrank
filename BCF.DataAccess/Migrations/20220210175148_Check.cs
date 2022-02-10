using Microsoft.EntityFrameworkCore.Migrations;

namespace BCF.DataAccess.Migrations
{
    public partial class Check : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_ID",
                table: "Warehouses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "_ID",
                table: "Vehicles",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Warehouses",
                newName: "_ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vehicles",
                newName: "_ID");
        }
    }
}

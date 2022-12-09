using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseInformationSystem.Migrations
{
    public partial class TestSanya : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Locations_RackNumber_ShelfNumber_AddressId",
                table: "Locations");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_RackNumber_ShelfNumber",
                table: "Locations",
                columns: new[] { "RackNumber", "ShelfNumber" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Locations_RackNumber_ShelfNumber",
                table: "Locations");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_RackNumber_ShelfNumber_AddressId",
                table: "Locations",
                columns: new[] { "RackNumber", "ShelfNumber", "AddressId" },
                unique: true);
        }
    }
}

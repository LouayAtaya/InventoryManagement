using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Infrastructure.Data.Migrations
{
    public partial class ItemOperationTableSetWarehouseColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Warehouse_Id",
                table: "ItemOperations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ItemOperations_Warehouse_Id",
                table: "ItemOperations",
                column: "Warehouse_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOperations_Warehouses_Warehouse_Id",
                table: "ItemOperations",
                column: "Warehouse_Id",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemOperations_Warehouses_Warehouse_Id",
                table: "ItemOperations");

            migrationBuilder.DropIndex(
                name: "IX_ItemOperations_Warehouse_Id",
                table: "ItemOperations");

            migrationBuilder.DropColumn(
                name: "Warehouse_Id",
                table: "ItemOperations");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Infrastructure.Data.Migrations
{
    public partial class WarehouseItemTableRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseItem_Items_Item_Id",
                table: "WarehouseItem");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseItem_Warehouses_Warehouse_Id",
                table: "WarehouseItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WarehouseItem",
                table: "WarehouseItem");

            migrationBuilder.RenameTable(
                name: "WarehouseItem",
                newName: "Warehouse_Item");

            migrationBuilder.RenameIndex(
                name: "IX_WarehouseItem_Warehouse_Id",
                table: "Warehouse_Item",
                newName: "IX_Warehouse_Item_Warehouse_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouse_Item",
                table: "Warehouse_Item",
                columns: new[] { "Item_Id", "Warehouse_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Item_Items_Item_Id",
                table: "Warehouse_Item",
                column: "Item_Id",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Item_Warehouses_Warehouse_Id",
                table: "Warehouse_Item",
                column: "Warehouse_Id",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Item_Items_Item_Id",
                table: "Warehouse_Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Item_Warehouses_Warehouse_Id",
                table: "Warehouse_Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouse_Item",
                table: "Warehouse_Item");

            migrationBuilder.RenameTable(
                name: "Warehouse_Item",
                newName: "WarehouseItem");

            migrationBuilder.RenameIndex(
                name: "IX_Warehouse_Item_Warehouse_Id",
                table: "WarehouseItem",
                newName: "IX_WarehouseItem_Warehouse_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarehouseItem",
                table: "WarehouseItem",
                columns: new[] { "Item_Id", "Warehouse_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseItem_Items_Item_Id",
                table: "WarehouseItem",
                column: "Item_Id",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseItem_Warehouses_Warehouse_Id",
                table: "WarehouseItem",
                column: "Warehouse_Id",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

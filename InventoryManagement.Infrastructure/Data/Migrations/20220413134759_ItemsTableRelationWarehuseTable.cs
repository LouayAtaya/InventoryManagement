using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Infrastructure.Data.Migrations
{
    public partial class ItemsTableRelationWarehuseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Warehouses_Warehouse_Id",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_Warehouse_Id",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Warehouse_Id",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Items",
                newName: "TotalQuantity");

            migrationBuilder.CreateTable(
                name: "WarehouseItem",
                columns: table => new
                {
                    Item_Id = table.Column<int>(nullable: false),
                    Warehouse_Id = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseItem", x => new { x.Item_Id, x.Warehouse_Id });
                    table.ForeignKey(
                        name: "FK_WarehouseItem_Items_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarehouseItem_Warehouses_Warehouse_Id",
                        column: x => x.Warehouse_Id,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseItem_Warehouse_Id",
                table: "WarehouseItem",
                column: "Warehouse_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarehouseItem");

            migrationBuilder.RenameColumn(
                name: "TotalQuantity",
                table: "Items",
                newName: "Quantity");

            migrationBuilder.AddColumn<int>(
                name: "Warehouse_Id",
                table: "Items",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_Warehouse_Id",
                table: "Items",
                column: "Warehouse_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Warehouses_Warehouse_Id",
                table: "Items",
                column: "Warehouse_Id",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

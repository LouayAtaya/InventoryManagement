using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Infrastructure.Data.Migrations
{
    public partial class SaleOrderTableAlterTobeBasedOnWarehouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleOrders_Accounts_CustomerId",
                table: "SaleOrders");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "SaleOrders",
                newName: "Customer_Id");

            migrationBuilder.RenameIndex(
                name: "IX_SaleOrders_CustomerId",
                table: "SaleOrders",
                newName: "IX_SaleOrders_Customer_Id");

            migrationBuilder.AddColumn<int>(
                name: "Warehouse_Id",
                table: "SaleOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrders_Warehouse_Id",
                table: "SaleOrders",
                column: "Warehouse_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOrders_Accounts_Customer_Id",
                table: "SaleOrders",
                column: "Customer_Id",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOrders_Warehouses_Warehouse_Id",
                table: "SaleOrders",
                column: "Warehouse_Id",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleOrders_Accounts_Customer_Id",
                table: "SaleOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleOrders_Warehouses_Warehouse_Id",
                table: "SaleOrders");

            migrationBuilder.DropIndex(
                name: "IX_SaleOrders_Warehouse_Id",
                table: "SaleOrders");

            migrationBuilder.DropColumn(
                name: "Warehouse_Id",
                table: "SaleOrders");

            migrationBuilder.RenameColumn(
                name: "Customer_Id",
                table: "SaleOrders",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleOrders_Customer_Id",
                table: "SaleOrders",
                newName: "IX_SaleOrders_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOrders_Accounts_CustomerId",
                table: "SaleOrders",
                column: "CustomerId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

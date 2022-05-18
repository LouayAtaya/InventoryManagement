using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Infrastructure.Data.Migrations
{
    public partial class SaleOrderProcessTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "Warehouse_Items");

            migrationBuilder.RenameIndex(
                name: "IX_Warehouse_Item_Warehouse_Id",
                table: "Warehouse_Items",
                newName: "IX_Warehouse_Items_Warehouse_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouse_Items",
                table: "Warehouse_Items",
                columns: new[] { "Item_Id", "Warehouse_Id" });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AccountCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AccountType = table.Column<byte>(type: "tinyint", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeActivatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeActivatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TotalAmount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TotalOrderPrice = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeActivatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeActivatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleOrders_Accounts_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleOrder_Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_Id = table.Column<int>(type: "int", nullable: false),
                    SaleOrder_Id = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    SubTotal = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrder_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleOrder_Items_Items_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleOrder_Items_SaleOrders_SaleOrder_Id",
                        column: x => x.SaleOrder_Id,
                        principalTable: "SaleOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountCode",
                table: "Accounts",
                column: "AccountCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Name",
                table: "Accounts",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrder_Items_Item_Id",
                table: "SaleOrder_Items",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrder_Items_SaleOrder_Id",
                table: "SaleOrder_Items",
                column: "SaleOrder_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrders_CustomerId",
                table: "SaleOrders",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Items_Items_Item_Id",
                table: "Warehouse_Items",
                column: "Item_Id",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Items_Warehouses_Warehouse_Id",
                table: "Warehouse_Items",
                column: "Warehouse_Id",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Items_Items_Item_Id",
                table: "Warehouse_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Items_Warehouses_Warehouse_Id",
                table: "Warehouse_Items");

            migrationBuilder.DropTable(
                name: "SaleOrder_Items");

            migrationBuilder.DropTable(
                name: "SaleOrders");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouse_Items",
                table: "Warehouse_Items");

            migrationBuilder.RenameTable(
                name: "Warehouse_Items",
                newName: "Warehouse_Item");

            migrationBuilder.RenameIndex(
                name: "IX_Warehouse_Items_Warehouse_Id",
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
    }
}

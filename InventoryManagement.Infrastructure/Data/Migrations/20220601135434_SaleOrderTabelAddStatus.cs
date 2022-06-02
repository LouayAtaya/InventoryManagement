using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Infrastructure.Data.Migrations
{
    public partial class SaleOrderTabelAddStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "SaleOrderStatus",
                table: "SaleOrders",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaleOrderStatus",
                table: "SaleOrders");
        }
    }
}

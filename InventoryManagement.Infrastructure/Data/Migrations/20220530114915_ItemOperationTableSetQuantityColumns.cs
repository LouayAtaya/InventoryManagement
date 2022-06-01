using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Infrastructure.Data.Migrations
{
    public partial class ItemOperationTableSetQuantityColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ItemOperations",
                newName: "PreviousQuantity");

            migrationBuilder.AddColumn<int>(
                name: "AffectedQuantity",
                table: "ItemOperations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AffectedQuantity",
                table: "ItemOperations");

            migrationBuilder.RenameColumn(
                name: "PreviousQuantity",
                table: "ItemOperations",
                newName: "Quantity");
        }
    }
}

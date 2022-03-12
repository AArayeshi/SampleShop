using Microsoft.EntityFrameworkCore.Migrations;

namespace Sample.Shop.Data.Migrations
{
    public partial class ChangeCartProductQuantityType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "CartProducts",
                newName: "Quantity");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "CartProducts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "CartProducts",
                newName: "quantity");

            migrationBuilder.AlterColumn<int>(
                name: "quantity",
                table: "CartProducts",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace TrendyShop.Migrations
{
    public partial class ShoppingCarForeignKeysDefinedAsPKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCars",
                table: "ShoppingCars");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCars_UserId",
                table: "ShoppingCars");

            migrationBuilder.DropColumn(
                name: "ShoppingCarId",
                table: "ShoppingCars");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCars",
                table: "ShoppingCars",
                columns: new[] { "UserId", "ShoppingListId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCars",
                table: "ShoppingCars");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCarId",
                table: "ShoppingCars",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCars",
                table: "ShoppingCars",
                column: "ShoppingCarId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCars_UserId",
                table: "ShoppingCars",
                column: "UserId");
        }
    }
}

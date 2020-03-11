using Microsoft.EntityFrameworkCore.Migrations;

namespace TrendyShop.Migrations
{
    public partial class ShoppingCarHasOnlyShoppingListIdAsPKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCars",
                table: "ShoppingCars");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCars_ShoppingListId",
                table: "ShoppingCars");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCars",
                table: "ShoppingCars",
                column: "ShoppingListId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCars_UserId",
                table: "ShoppingCars",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCars",
                table: "ShoppingCars");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCars_UserId",
                table: "ShoppingCars");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCars",
                table: "ShoppingCars",
                columns: new[] { "UserId", "ShoppingListId" });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCars_ShoppingListId",
                table: "ShoppingCars",
                column: "ShoppingListId");
        }
    }
}

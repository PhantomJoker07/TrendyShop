using Microsoft.EntityFrameworkCore.Migrations;

namespace TrendyShop.Migrations
{
    public partial class AddedUserReferenceAsForeignKeyInShoppingCarModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCars_UserId",
                table: "ShoppingCars",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCars_Users_UserId",
                table: "ShoppingCars",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCars_Users_UserId",
                table: "ShoppingCars");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCars_UserId",
                table: "ShoppingCars");
        }
    }
}

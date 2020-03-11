using Microsoft.EntityFrameworkCore.Migrations;

namespace TrendyShop.Migrations
{
    public partial class IdNamesUpdatedInCategoryAndShoppingListModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCars_ShoppingList_ShoppingListId",
                table: "ShoppingCars");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingList_Articles_ShoppingList_ShoppingListId",
                table: "ShoppingList_Articles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingList",
                table: "ShoppingList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ShoppingList");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingListId",
                table: "ShoppingList",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Categories",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingList",
                table: "ShoppingList",
                column: "ShoppingListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCars_ShoppingList_ShoppingListId",
                table: "ShoppingCars",
                column: "ShoppingListId",
                principalTable: "ShoppingList",
                principalColumn: "ShoppingListId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingList_Articles_ShoppingList_ShoppingListId",
                table: "ShoppingList_Articles",
                column: "ShoppingListId",
                principalTable: "ShoppingList",
                principalColumn: "ShoppingListId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCars_ShoppingList_ShoppingListId",
                table: "ShoppingCars");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingList_Articles_ShoppingList_ShoppingListId",
                table: "ShoppingList_Articles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingList",
                table: "ShoppingList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ShoppingListId",
                table: "ShoppingList");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ShoppingList",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingList",
                table: "ShoppingList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCars_ShoppingList_ShoppingListId",
                table: "ShoppingCars",
                column: "ShoppingListId",
                principalTable: "ShoppingList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingList_Articles_ShoppingList_ShoppingListId",
                table: "ShoppingList_Articles",
                column: "ShoppingListId",
                principalTable: "ShoppingList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

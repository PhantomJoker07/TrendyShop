using Microsoft.EntityFrameworkCore.Migrations;

namespace TrendyShop.Migrations
{
    public partial class ShoppingList_ArticleForeignKeysDefinedAsPKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingList_Articles",
                table: "ShoppingList_Articles");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingList_Articles_ShoppingListId",
                table: "ShoppingList_Articles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ShoppingList_Articles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingList_Articles",
                table: "ShoppingList_Articles",
                columns: new[] { "ShoppingListId", "ArticleId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingList_Articles",
                table: "ShoppingList_Articles");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ShoppingList_Articles",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingList_Articles",
                table: "ShoppingList_Articles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingList_Articles_ShoppingListId",
                table: "ShoppingList_Articles",
                column: "ShoppingListId");
        }
    }
}

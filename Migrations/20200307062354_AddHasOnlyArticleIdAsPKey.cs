using Microsoft.EntityFrameworkCore.Migrations;

namespace TrendyShop.Migrations
{
    public partial class AddHasOnlyArticleIdAsPKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Adds",
                table: "Adds");

            migrationBuilder.DropIndex(
                name: "IX_Adds_ArticleId",
                table: "Adds");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adds",
                table: "Adds",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Adds_UserId",
                table: "Adds",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Adds",
                table: "Adds");

            migrationBuilder.DropIndex(
                name: "IX_Adds_UserId",
                table: "Adds");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adds",
                table: "Adds",
                columns: new[] { "UserId", "ArticleId" });

            migrationBuilder.CreateIndex(
                name: "IX_Adds_ArticleId",
                table: "Adds",
                column: "ArticleId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace TrendyShop.Migrations
{
    public partial class AddForeignKeysDefinedAsPKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Adds",
                table: "Adds");

            migrationBuilder.DropIndex(
                name: "IX_Adds_UserId",
                table: "Adds");

            migrationBuilder.DropColumn(
                name: "AddId",
                table: "Adds");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adds",
                table: "Adds",
                columns: new[] { "UserId", "ArticleId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Adds",
                table: "Adds");

            migrationBuilder.AddColumn<int>(
                name: "AddId",
                table: "Adds",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adds",
                table: "Adds",
                column: "AddId");

            migrationBuilder.CreateIndex(
                name: "IX_Adds_UserId",
                table: "Adds",
                column: "UserId");
        }
    }
}

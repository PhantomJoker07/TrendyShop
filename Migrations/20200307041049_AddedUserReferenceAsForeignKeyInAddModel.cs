using Microsoft.EntityFrameworkCore.Migrations;

namespace TrendyShop.Migrations
{
    public partial class AddedUserReferenceAsForeignKeyInAddModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Adds_UserId",
                table: "Adds",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adds_Users_UserId",
                table: "Adds",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adds_Users_UserId",
                table: "Adds");

            migrationBuilder.DropIndex(
                name: "IX_Adds_UserId",
                table: "Adds");
        }
    }
}

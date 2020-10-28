using Microsoft.EntityFrameworkCore.Migrations;

namespace TrendyShop.Migrations
{
    public partial class AddedPaymentGatewayModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Adds_SellerId_ArticleId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SellerId_ArticleId",
                table: "Orders");

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
                name: "IX_Orders_ArticleId",
                table: "Orders",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SellerId",
                table: "Orders",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Adds_UserId",
                table: "Adds",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Adds_ArticleId",
                table: "Orders",
                column: "ArticleId",
                principalTable: "Adds",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_SellerId",
                table: "Orders",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Adds_ArticleId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_SellerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ArticleId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SellerId",
                table: "Orders");

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
                name: "IX_Orders_SellerId_ArticleId",
                table: "Orders",
                columns: new[] { "SellerId", "ArticleId" });

            migrationBuilder.CreateIndex(
                name: "IX_Adds_ArticleId",
                table: "Adds",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Adds_SellerId_ArticleId",
                table: "Orders",
                columns: new[] { "SellerId", "ArticleId" },
                principalTable: "Adds",
                principalColumns: new[] { "UserId", "ArticleId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}

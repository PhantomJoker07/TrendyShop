using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrendyShop.Migrations
{
    public partial class AddedPaidColumnToAuctionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Paid",
                table: "Auctions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "AuctionOrders",
                columns: table => new
                {
                    Date = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<string>(nullable: false),
                    ArticleId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    ShippingCharge = table.Column<float>(nullable: false),
                    Paid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionOrders", x => new { x.Date, x.CustomerId, x.ArticleId });
                    table.ForeignKey(
                        name: "FK_AuctionOrders_Auctions_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Auctions",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuctionOrders_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuctionOrders_ArticleId",
                table: "AuctionOrders",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionOrders_CustomerId",
                table: "AuctionOrders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuctionOrders");

            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Auctions");
        }
    }
}

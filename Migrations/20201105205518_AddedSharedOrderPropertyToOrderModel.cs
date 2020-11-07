using Microsoft.EntityFrameworkCore.Migrations;

namespace TrendyShop.Migrations
{
    public partial class AddedSharedOrderPropertyToOrderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SharedOrder",
                table: "Orders",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SharedOrder",
                table: "Orders");
        }
    }
}

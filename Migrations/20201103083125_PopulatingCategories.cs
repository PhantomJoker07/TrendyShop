using Microsoft.EntityFrameworkCore.Migrations;

namespace TrendyShop.Migrations
{
    public partial class PopulatingCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
              table: "Categories",
              column: "Name",
              value: "Accesorios");

            migrationBuilder.InsertData(
                table: "Categories",
                column: "Name",
                value: "Tecnología");

            migrationBuilder.InsertData(
                table: "Categories",
                column: "Name",
                value: "Calzado");

            migrationBuilder.InsertData(
                table: "Categories",
                column: "Name",
                value: "Electrodomésticos");

            migrationBuilder.InsertData(
                table: "Categories",
                column: "Name",
                value: "Juguetes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

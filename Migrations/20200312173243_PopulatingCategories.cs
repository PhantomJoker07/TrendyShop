using Microsoft.EntityFrameworkCore.Migrations;

namespace TrendyShop.Migrations
{
    public partial class PopulatingCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,] {
                    {1,"Electrodomésticos" },
                    {2,"Muebles/Decoración"},
                    {3,"Ropa/Zapatos/Accesorios"},
                    {4,"Joyas/Relojes" },
                    {5,"Libros/Revistas" },
                    {6,"Antiguedades/Colección" },
                    {7,"Televisores" },
                    {8,"Celulares/Lineas/Accesorios" },
                    {9,"Otro" }
                }
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

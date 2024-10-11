using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace apirestful.Migrations
{
    /// <inheritdoc />
    public partial class AgreggateSedders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "description", "idCategory", "name", "price", "stock" },
                values: new object[,]
                {
                    { 1, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 1, "tarjeta rpi", 941.45000000000005, 67 },
                    { 2, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 2, "microhondas", 828.63999999999999, 95 },
                    { 3, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 1, "Tarjeta wifi", 175.93000000000001, 73 },
                    { 4, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 3, "camiseta", 253.38, 99 },
                    { 5, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 3, "bufanda", 377.18000000000001, 73 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 5);
        }
    }
}

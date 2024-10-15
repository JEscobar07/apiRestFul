using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace apirestful.Migrations
{
    /// <inheritdoc />
    public partial class CreatingOrderProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "order_products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idProduct = table.Column<int>(type: "int", nullable: false),
                    idOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_products_orders_idOrder",
                        column: x => x.idOrder,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_products_products_idProduct",
                        column: x => x.idProduct,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_order_products_idOrder",
                table: "order_products",
                column: "idOrder");

            migrationBuilder.CreateIndex(
                name: "IX_order_products_idProduct",
                table: "order_products",
                column: "idProduct");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_products");

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "description", "idCategory", "name", "price", "stock" },
                values: new object[,]
                {
                    { 1, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 3, "Intelligent Wooden Pizza", 427.63, 43 },
                    { 2, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 3, "Intelligent Wooden Fish", 916.77999999999997, 32 },
                    { 3, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 2, "Handmade Steel Soap", 126.94, 93 },
                    { 4, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 1, "Refined Concrete Pants", 935.34000000000003, 23 },
                    { 5, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 1, "Handcrafted Rubber Towels", 443.35000000000002, 94 }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apirestful.Migrations
{
    /// <inheritdoc />
    public partial class alterIdCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(type: "datetime(6)", maxLength: 100, nullable: false),
                    idCustomer = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_orders_customers_idCustomer",
                        column: x => x.idCustomer,
                        principalTable: "customers",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

       
            migrationBuilder.CreateIndex(
                name: "IX_orders_idCustomer",
                table: "orders",
                column: "idCustomer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "description", "idCategory", "name", "price", "stock" },
                values: new object[] { "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 1, "Sleek Granite Mouse", 508.82999999999998, 33 });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "description", "idCategory", "name", "price", "stock" },
                values: new object[] { "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 1, "Licensed Frozen Car", 519.01999999999998, 57 });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "description", "idCategory", "name", "price", "stock" },
                values: new object[] { "The Football Is Good For Training And Recreational Purposes", 3, "Ergonomic Concrete Bike", 798.44000000000005, 49 });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "description", "idCategory", "name", "price", "stock" },
                values: new object[] { "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 3, "Generic Metal Ball", 981.53999999999996, 16 });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "description", "idCategory", "name", "price", "stock" },
                values: new object[] { "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 2, "Intelligent Soft Soap", 881.61000000000001, 48 });
        }
    }
}

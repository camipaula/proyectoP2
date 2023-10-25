using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIPROYECTO1.Migrations
{
    /// <inheritdoc />
    public partial class BaseP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prendas",
                columns: table => new
                {
                    IdPrenda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prendas", x => x.IdPrenda);
                });

            migrationBuilder.InsertData(
                table: "Prendas",
                columns: new[] { "IdPrenda", "Cantidad", "Descripcion", "Marca", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, 2, "Pantalon", "zara", "prenda1", 40f },
                    { 2, 3, "falda", "zara", "prenda2", 20f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prendas");
        }
    }
}

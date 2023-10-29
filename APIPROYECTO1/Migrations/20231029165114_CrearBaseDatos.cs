using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIPROYECTO1.Migrations
{
    /// <inheritdoc />
    public partial class CrearBaseDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accesorios",
                columns: table => new
                {
                    IdAccesorio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesorios", x => x.IdAccesorio);
                });

            migrationBuilder.CreateTable(
                name: "Prendas",
                columns: table => new
                {
                    IdPrenda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prendas", x => x.IdPrenda);
                });

            migrationBuilder.CreateTable(
                name: "promociones",
                columns: table => new
                {
                    IdPromocion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_promociones", x => x.IdPromocion);
                });

            migrationBuilder.InsertData(
                table: "Accesorios",
                columns: new[] { "IdAccesorio", "Cantidad", "Descripcion", "Marca", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, 2, "Collar blanco de plata", "cartier", "Collar", 11f },
                    { 2, 3, "Aretes largos", "buccellati", "Aretes", 20f }
                });

            migrationBuilder.InsertData(
                table: "Prendas",
                columns: new[] { "IdPrenda", "Cantidad", "Categoria", "Descripcion", "Marca", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, 2, "Deportivo", "Pantalon", "zara", "prenda1", 40f },
                    { 2, 3, "Casual", "falda", "zara", "prenda2", 20f }
                });

            migrationBuilder.InsertData(
                table: "promociones",
                columns: new[] { "IdPromocion", "Cantidad", "Descripcion", "Marca", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, 2, "Blusa azul", "shein", "Promocion 1", 13f },
                    { 2, 3, "Aretes largos", "shein", "Promocion 2", 15f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accesorios");

            migrationBuilder.DropTable(
                name: "Prendas");

            migrationBuilder.DropTable(
                name: "promociones");
        }
    }
}

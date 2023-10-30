using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIPROYECTO1.Migrations
{
    /// <inheritdoc />
    public partial class Tablass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prendas",
                keyColumn: "IdPrenda",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prendas",
                keyColumn: "IdPrenda",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Prendas");

            migrationBuilder.DropColumn(
                name: "Marca",
                table: "Prendas");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaIdCategoria",
                table: "Prendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MarcaIdMarca",
                table: "Prendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prendas_CategoriaIdCategoria",
                table: "Prendas",
                column: "CategoriaIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Prendas_MarcaIdMarca",
                table: "Prendas",
                column: "MarcaIdMarca");

            migrationBuilder.AddForeignKey(
                name: "FK_Prendas_Categorias_CategoriaIdCategoria",
                table: "Prendas",
                column: "CategoriaIdCategoria",
                principalTable: "Categorias",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prendas_Marcas_MarcaIdMarca",
                table: "Prendas",
                column: "MarcaIdMarca",
                principalTable: "Marcas",
                principalColumn: "IdMarca",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prendas_Categorias_CategoriaIdCategoria",
                table: "Prendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Prendas_Marcas_MarcaIdMarca",
                table: "Prendas");

            migrationBuilder.DropIndex(
                name: "IX_Prendas_CategoriaIdCategoria",
                table: "Prendas");

            migrationBuilder.DropIndex(
                name: "IX_Prendas_MarcaIdMarca",
                table: "Prendas");

            migrationBuilder.DropColumn(
                name: "CategoriaIdCategoria",
                table: "Prendas");

            migrationBuilder.DropColumn(
                name: "MarcaIdMarca",
                table: "Prendas");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Prendas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "Prendas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Prendas",
                columns: new[] { "IdPrenda", "Cantidad", "Categoria", "Descripcion", "Marca", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, 2, "Deportivo", "Pantalon", "zara", "prenda1", 40f },
                    { 2, 3, "Casual", "falda", "zara", "prenda2", 20f }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDLUCY_CodeFirst_Crud.Migrations
{
    public partial class MBdLucyV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Codigo_Categoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Categoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion_Categoria = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Estado_Categoria = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Codigo_Categoria);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Codigo_Empresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Empresa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion_Empresa = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Codigo_Empresa);
                });

            migrationBuilder.CreateTable(
                name: "Presentacions",
                columns: table => new
                {
                    Codigo_Presentacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Presentacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Siglas_Presentacion = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentacions", x => x.Codigo_Presentacion);
                });

            migrationBuilder.CreateTable(
                name: "Subcategorias",
                columns: table => new
                {
                    Codigo_Subcategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo_Categoria = table.Column<int>(type: "int", nullable: false),
                    Nombre_Subcategoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion_Subcategoria = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Estado_Subcategoria = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategorias", x => x.Codigo_Subcategoria);
                    table.ForeignKey(
                        name: "FK_Subcategorias_Categorias_Codigo_Categoria",
                        column: x => x.Codigo_Categoria,
                        principalTable: "Categorias",
                        principalColumn: "Codigo_Categoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Codigo_Marca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo_Empresa = table.Column<int>(type: "int", nullable: false),
                    Nombre_Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion_Marca = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Codigo_Marca);
                    table.ForeignKey(
                        name: "FK_Marcas_Empresas_Codigo_Empresa",
                        column: x => x.Codigo_Empresa,
                        principalTable: "Empresas",
                        principalColumn: "Codigo_Empresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Codigo_Producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo_Subcategoria = table.Column<int>(type: "int", nullable: false),
                    Codigo_Presentacion = table.Column<int>(type: "int", nullable: false),
                    Codigo_Marca = table.Column<int>(type: "int", nullable: false),
                    Nombre_Producto = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Codigo_De_Barra = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    Stock_Producto = table.Column<float>(type: "real", nullable: false),
                    Precio_Compra_Producto = table.Column<float>(type: "real", nullable: false),
                    Precio_Venta_Producto = table.Column<float>(type: "real", nullable: false),
                    Descripcion_Producto = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    NombreImage = table.Column<string>(type: "nvarchar(80)", nullable: true),
                    Estado_Producto = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Codigo_Producto);
                    table.ForeignKey(
                        name: "FK_Productos_Marcas_Codigo_Marca",
                        column: x => x.Codigo_Marca,
                        principalTable: "Marcas",
                        principalColumn: "Codigo_Marca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Presentacions_Codigo_Presentacion",
                        column: x => x.Codigo_Presentacion,
                        principalTable: "Presentacions",
                        principalColumn: "Codigo_Presentacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Subcategorias_Codigo_Subcategoria",
                        column: x => x.Codigo_Subcategoria,
                        principalTable: "Subcategorias",
                        principalColumn: "Codigo_Subcategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidencias",
                columns: table => new
                {
                    Codigo_Incidencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo_Producto = table.Column<int>(type: "int", nullable: false),
                    Descripcion_Incidencia = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Cantidad_Incidencia = table.Column<int>(type: "int", nullable: false),
                    Fecha_Incidencia = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidencias", x => x.Codigo_Incidencia);
                    table.ForeignKey(
                        name: "FK_Incidencias_Productos_Codigo_Producto",
                        column: x => x.Codigo_Producto,
                        principalTable: "Productos",
                        principalColumn: "Codigo_Producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_Codigo_Producto",
                table: "Incidencias",
                column: "Codigo_Producto");

            migrationBuilder.CreateIndex(
                name: "IX_Marcas_Codigo_Empresa",
                table: "Marcas",
                column: "Codigo_Empresa");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Codigo_Marca",
                table: "Productos",
                column: "Codigo_Marca");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Codigo_Presentacion",
                table: "Productos",
                column: "Codigo_Presentacion");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Codigo_Subcategoria",
                table: "Productos",
                column: "Codigo_Subcategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategorias_Codigo_Categoria",
                table: "Subcategorias",
                column: "Codigo_Categoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidencias");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Presentacions");

            migrationBuilder.DropTable(
                name: "Subcategorias");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}

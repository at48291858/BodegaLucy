using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDLUCY_CodeFirst_Crud.Migrations
{
    public partial class BDLUCY : Migration
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
                name: "Clientes",
                columns: table => new
                {
                    Codigo_Cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Cliente = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    Apellido_Paterno_Cliente = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Apellido_Materno_Cliente = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Tipo_Documento_Cliente = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    Documento_Cliente = table.Column<string>(type: "nvarchar(13)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Codigo_Cliente);
                });

            migrationBuilder.CreateTable(
                name: "Distribuidor",
                columns: table => new
                {
                    Codigo_Distribuidor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Razon_Social_Distribuidor = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    RUC_Distribuidor = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    Direccion_Distribuidor = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    Telefono_Distribuidor = table.Column<string>(type: "nvarchar(9)", nullable: true),
                    Nombre_Contacto = table.Column<string>(type: "nvarchar(70)", nullable: true),
                    Telefono_Contacto = table.Column<string>(type: "nvarchar(70)", nullable: true),
                    Estado_Distribuidor = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distribuidor", x => x.Codigo_Distribuidor);
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
                name: "Paquete",
                columns: table => new
                {
                    Codigo_Paquete = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Paquete = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Cantidad_Por_Paquete = table.Column<int>(type: "int", nullable: false),
                    Contenido_Por_Unidad = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Descripcion_Paquete = table.Column<string>(type: "nvarchar(70)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquete", x => x.Codigo_Paquete);
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
                name: "Usuario",
                columns: table => new
                {
                    Codigo_Usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI_Usuario = table.Column<string>(type: "nvarchar(8)", nullable: true),
                    Nombre_Usuario = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    Apellido_Paterno_Usuario = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Apellido_Materno_Usuario = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Direccion_Usuario = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    Correo_Usuario = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Telefono_Usuario = table.Column<string>(type: "nvarchar(9)", nullable: true),
                    User_Usuario = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    clave_Usuario = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Pregunta_Secreta = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Respuesta_Secreta = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Estado_Usuario = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Codigo_Usuario);
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
                name: "Compra",
                columns: table => new
                {
                    Codigo_Compra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Compra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo_Comprobante = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Serie_Comprobante_Compra = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    Numero_Comprobante_Compra = table.Column<string>(type: "nvarchar(8)", nullable: true),
                    Codigo_Usuario = table.Column<int>(type: "int", nullable: false),
                    Codigo_Distribuidor = table.Column<int>(type: "int", nullable: false),
                    IGV_Compra = table.Column<float>(type: "real", nullable: false),
                    Subtotal_Compra = table.Column<float>(type: "real", nullable: false),
                    Total_Compra = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.Codigo_Compra);
                    table.ForeignKey(
                        name: "FK_Compra_Distribuidor_Codigo_Distribuidor",
                        column: x => x.Codigo_Distribuidor,
                        principalTable: "Distribuidor",
                        principalColumn: "Codigo_Distribuidor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compra_Usuario_Codigo_Usuario",
                        column: x => x.Codigo_Usuario,
                        principalTable: "Usuario",
                        principalColumn: "Codigo_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Codigo_Venta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Serie_Comprobante_Venta = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    Numero_Comprobante = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Fecha_Venta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_Venta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto_Total_Venta = table.Column<float>(type: "real", nullable: false),
                    Codigo_Usuario = table.Column<int>(type: "int", nullable: false),
                    Codigo_Cliente = table.Column<int>(type: "int", nullable: false),
                    Subtotal_Venta = table.Column<float>(type: "real", nullable: false),
                    Descuento_Venta = table.Column<float>(type: "real", nullable: false),
                    IGV_Venta = table.Column<float>(type: "real", nullable: false),
                    Total_Venta = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Codigo_Venta);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_Codigo_Cliente",
                        column: x => x.Codigo_Cliente,
                        principalTable: "Clientes",
                        principalColumn: "Codigo_Cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Usuario_Codigo_Usuario",
                        column: x => x.Codigo_Usuario,
                        principalTable: "Usuario",
                        principalColumn: "Codigo_Usuario",
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
                name: "Detalle_Compra",
                columns: table => new
                {
                    Codigo_Detalle_Compra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo_Compra = table.Column<int>(type: "int", nullable: false),
                    Codigo_Paquete = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio_Unitario = table.Column<float>(type: "real", nullable: false),
                    Importe_Detalle_Compra = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_Compra", x => x.Codigo_Detalle_Compra);
                    table.ForeignKey(
                        name: "FK_Detalle_Compra_Compra_Codigo_Compra",
                        column: x => x.Codigo_Compra,
                        principalTable: "Compra",
                        principalColumn: "Codigo_Compra",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalle_Compra_Paquete_Codigo_Paquete",
                        column: x => x.Codigo_Paquete,
                        principalTable: "Paquete",
                        principalColumn: "Codigo_Paquete",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detalle_Ventas",
                columns: table => new
                {
                    Codigo_Detalle_Venta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo_Producto = table.Column<int>(type: "int", nullable: false),
                    Codigo_Venta = table.Column<int>(type: "int", nullable: false),
                    Cantidad_Detalle_Venta = table.Column<int>(type: "int", nullable: false),
                    Importe_Detalle_Venta = table.Column<float>(type: "real", nullable: false),
                    Descuento_Detalle_Venta = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_Ventas", x => x.Codigo_Detalle_Venta);
                    table.ForeignKey(
                        name: "FK_detalle_Ventas_Productos_Codigo_Producto",
                        column: x => x.Codigo_Producto,
                        principalTable: "Productos",
                        principalColumn: "Codigo_Producto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_Ventas_Ventas_Codigo_Venta",
                        column: x => x.Codigo_Venta,
                        principalTable: "Ventas",
                        principalColumn: "Codigo_Venta",
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

            migrationBuilder.CreateTable(
                name: "Ofertas",
                columns: table => new
                {
                    Codigo_Oferta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo_Producto = table.Column<int>(type: "int", nullable: false),
                    Cantidad_Oferta = table.Column<int>(type: "int", nullable: false),
                    Descuento_Oferta = table.Column<float>(type: "real", nullable: false),
                    Descripcion_Oferta = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Fecha_Inicio_Oferta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Final_Oferta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofertas", x => x.Codigo_Oferta);
                    table.ForeignKey(
                        name: "FK_Ofertas_Productos_Codigo_Producto",
                        column: x => x.Codigo_Producto,
                        principalTable: "Productos",
                        principalColumn: "Codigo_Producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compra_Codigo_Distribuidor",
                table: "Compra",
                column: "Codigo_Distribuidor");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_Codigo_Usuario",
                table: "Compra",
                column: "Codigo_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Compra_Codigo_Compra",
                table: "Detalle_Compra",
                column: "Codigo_Compra");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Compra_Codigo_Paquete",
                table: "Detalle_Compra",
                column: "Codigo_Paquete");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_Ventas_Codigo_Producto",
                table: "detalle_Ventas",
                column: "Codigo_Producto");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_Ventas_Codigo_Venta",
                table: "detalle_Ventas",
                column: "Codigo_Venta");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_Codigo_Producto",
                table: "Incidencias",
                column: "Codigo_Producto");

            migrationBuilder.CreateIndex(
                name: "IX_Marcas_Codigo_Empresa",
                table: "Marcas",
                column: "Codigo_Empresa");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_Codigo_Producto",
                table: "Ofertas",
                column: "Codigo_Producto");

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

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Codigo_Cliente",
                table: "Ventas",
                column: "Codigo_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Codigo_Usuario",
                table: "Ventas",
                column: "Codigo_Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle_Compra");

            migrationBuilder.DropTable(
                name: "detalle_Ventas");

            migrationBuilder.DropTable(
                name: "Incidencias");

            migrationBuilder.DropTable(
                name: "Ofertas");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Paquete");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Distribuidor");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Usuario");

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

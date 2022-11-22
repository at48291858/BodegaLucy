using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDLUCY_CodeFirst_Crud.Migrations
{
    public partial class MBdLucyV5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Detalle_Compras",
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
                    table.PrimaryKey("PK_Detalle_Compras", x => x.Codigo_Detalle_Compra);
                    table.ForeignKey(
                        name: "FK_Detalle_Compras_Compras_Codigo_Compra",
                        column: x => x.Codigo_Compra,
                        principalTable: "Compras",
                        principalColumn: "Codigo_Compra",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalle_Compras_Paquetes_Codigo_Paquete",
                        column: x => x.Codigo_Paquete,
                        principalTable: "Paquetes",
                        principalColumn: "Codigo_Paquete",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Compras_Codigo_Compra",
                table: "Detalle_Compras",
                column: "Codigo_Compra");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Compras_Codigo_Paquete",
                table: "Detalle_Compras",
                column: "Codigo_Paquete");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle_Compras");
        }
    }
}

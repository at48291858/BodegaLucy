using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDLUCY_CodeFirst_Crud.Migrations
{
    public partial class tuveFe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion_Oferta",
                table: "Ofertas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion_Oferta",
                table: "Ofertas",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");
        }
    }
}

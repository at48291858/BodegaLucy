using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BDLUCY_CodeFirst_Crud.Models
{
    public class Cliente
    {
        [Key] //Primary Key
        public int Codigo_Cliente { get; set; }
        //---------------------
        [Column(TypeName = "nvarchar(25)")]
        public string Nombre_Cliente { get; set; } = "";
        //---------------------
        [Column(TypeName = "nvarchar(20)")]
        public string Apellido_Paterno_Cliente { get; set; } = "";
        //---------------------
        [Column(TypeName = "nvarchar(20)")]
        public string Apellido_Materno_Cliente { get; set; } = "";
        //---------------------
        [Column(TypeName = "nvarchar(3)")]
        public string Tipo_Documento_Cliente { get; set; } = "";
        //---------------------
        [Column(TypeName = "nvarchar(13)")]
        public string Documento_Cliente { get; set; } = "";
    }
}

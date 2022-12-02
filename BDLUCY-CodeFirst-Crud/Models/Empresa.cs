using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BDLUCY_CodeFirst_Crud.Models
{
    public class Empresa
    {
        [Key]
        public int Codigo_Empresa { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "El nombre no ha sido ingresado")]
        [MaxLength(50, ErrorMessage = "Solo se puede ingresar 50 caracteres")]
        public string Nombre_Empresa { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [MaxLength(150, ErrorMessage = "Solo se puede ingresar 150 caracteres")]
        public string? Descripcion_Empresa { get; set; } = "";
    }
}

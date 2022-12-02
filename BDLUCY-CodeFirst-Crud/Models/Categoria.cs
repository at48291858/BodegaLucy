using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BDLUCY_CodeFirst_Crud.Models
{
    public class Categoria
    {
        [Key]
        public int Codigo_Categoria { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "El nombre no ha sido ingresado")]
        [MaxLength(50, ErrorMessage = "Solo se puede ingresar 50 caracteres")]
        public string Nombre_Categoria { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [MaxLength(150, ErrorMessage = "Solo se puede ingresar 150 caracteres")]
        public string? Descripcion_Categoria { get; set; } = "";
        public bool Estado_Categoria { get; set; }
    }
}

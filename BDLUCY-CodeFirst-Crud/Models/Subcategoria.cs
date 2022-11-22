using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BDLUCY_CodeFirst_Crud.Models
{
    public class Subcategoria
    {
        [Key]
        public int Codigo_Subcategoria { get; set; }
        [Required(ErrorMessage = "La categoria no ha sido seleccionada")]
        public int Codigo_Categoria { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "El nombre no ha sido ingresado")]
        [MaxLength(50, ErrorMessage = "Solo se puede ingresar 50 caracteres")]
        public string Nombre_Subcategoria { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [MaxLength(150, ErrorMessage = "Solo se puede ingresar 150 caracteres")]
        public string? Descripcion_Subcategoria { get; set; } = "";
        public bool Estado_Subcategoria { get; set; }
        [ForeignKey("Codigo_Categoria")]
        public Categoria? categoria { get; set; }
    }
}

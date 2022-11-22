using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BDLUCY_CodeFirst_Crud.Models
{
    public class Marca
    {
        [Key]
        public int Codigo_Marca { get; set; }
        [Required(ErrorMessage = "La empresa no ha sido seleccionada")]
        public int Codigo_Empresa { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "El nombre no ha sido ingresado")]
        [MaxLength(50, ErrorMessage = "Solo se puede ingresar 50 caracteres")]
        public string Nombre_Marca { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [MaxLength(150, ErrorMessage = "Solo se puede ingresar 150 caracteres")]
        public string? Descripcion_Marca { get; set; } = "";
        [ForeignKey("Codigo_Empresa")]
        public Empresa? empresa { get; set; }
    }
}

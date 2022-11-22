using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BDLUCY_CodeFirst_Crud.Models
{
    public class Presentacion
    {
        [Key]
        public int Codigo_Presentacion { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "El nombre no ha sido ingresado")]
        [MaxLength(50, ErrorMessage = "Solo se puede ingresar 50 caracteres")]
        public string Nombre_Presentacion { get; set; }
        [Column(TypeName = "nvarchar(3)")]
        [Required(ErrorMessage = "Las siglas no han sido ingresadas")]
        [MaxLength(3, ErrorMessage = "Solo se puede ingresar 3 caracteres")]
        public string Siglas_Presentacion { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BDLUCY_CodeFirst_Crud.Models
{
    public class Incidencia
    {
        [Key]
        public int Codigo_Incidencia { get; set; }
        [Required(ErrorMessage = "El producto no ha sido seleccionado")]
        public int Codigo_Producto { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required(ErrorMessage = "El nombre no ha sido ingresado")]
        [MaxLength(150, ErrorMessage = "Solo se puede ingresar 255 caracteres")]
        public string Descripcion_Incidencia { get; set; } = "";
        [Required(ErrorMessage = "La cantidad no ha sido ingresada")]
        public int Cantidad_Incidencia { get; set; }
        public DateTime Fecha_Incidencia { get; set; } = DateTime.Now;
        [ForeignKey("Codigo_Producto")]
        public Producto? producto { get; set; }
    }
}

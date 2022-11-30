using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BDLUCY_CodeFirst_Crud.Models
{
    public class Oferta
    {
        [Key] //Primary Key
        public int Codigo_Oferta { get; set; }
        //---------------------
        public int Codigo_Producto { get; set; }
        //---------------------
        [Required(ErrorMessage ="El campo es obligatorio")]
        public int Cantidad_Oferta { get; set; } = 0;
        //---------------------
        [Required(ErrorMessage = "El campo es obligatorio")]
        public float Descuento_Oferta { get; set; } = 0;
        //---------------------
        [Required(ErrorMessage = "El campo es obligatorio")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha_Inicio_Oferta { get; set; }
        //---------------------
        [Required(ErrorMessage = "El campo es obligatorio")]
        public DateTime Fecha_Final_Oferta { get; set; }
        //--------------------------------
        [ForeignKey("Codigo_Producto")]
        public Producto? producto { get; set; }
    }
}

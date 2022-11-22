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
        public int Cantidad_Oferta { get; set; } = 0;
        //---------------------
        public float Descuento_Oferta { get; set; } = 0;
        //---------------------
        [Column(TypeName = "nvarchar(100)")]
        public string Descripcion_Oferta { get; set; } = "";
        //---------------------
        public DateTime Fecha_Inicio_Oferta { get; set; }
        //---------------------
        public DateTime Fecha_Final_Oferta { get; set; }
        //--------------------------------
        [ForeignKey("Codigo_Producto")]
        public Producto producto { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BDLUCY_CodeFirst_Crud.Models
{
    public class Detalle_Venta
    {
        [Key] //Primary Key
        public int Codigo_Detalle_Venta { get; set; }
        //---------------------
        public int Codigo_Producto { get; set; }
        //---------------------
        public int Codigo_Venta { get; set; }
        //---------------------
        public int Cantidad_Detalle_Venta { get; set; } = 0;
        //---------------------
        public float Importe_Detalle_Venta { get; set; } = 0;
        //---------------------
        public float Descuento_Detalle_Venta { get; set; } = 0;
        //--------------------------------
        [ForeignKey("Codigo_Producto")]
        public Producto producto { get; set; }
        [ForeignKey("Codigo_Venta")]
        public Venta venta { get; set; }
    }
}

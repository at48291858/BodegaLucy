using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BDLUCY_CodeFirst_Crud.Models
{
    public class Venta
    {
        [Key] //Primary Key
        public int Codigo_Venta { get; set; }
        //---------------------
        [Column(TypeName = "nvarchar(4)")]
        public string Serie_Comprobante_Venta { get; set; } = "";
        //---------------------
        [Column(TypeName = "nvarchar(20)")]
        public string Numero_Comprobante { get; set; } = "";
        //---------------------
        public DateTime Fecha_Venta { get; set; } = DateTime.Now;
        //---------------------
        public DateTime Hora_Venta { get; set; }
        //---------------------
        public float Monto_Total_Venta { get; set; } = 0;
        //---------------------
        public int Codigo_Usuario { get; set; }
        //---------------------
        public int Codigo_Cliente { get; set; }
        //---------------------
        public float Subtotal_Venta { get; set; } = 0;
        //---------------------
        public float Descuento_Venta { get; set; } = 0;
        //---------------------
        public float IGV_Venta { get; set; } = 0;
        //---------------------
        public float Total_Venta { get; set; } = 0;
        //--------------------------------
        [ForeignKey("Codigo_Usuario")]
        public Usuario usuario { get; set; }
        //--------------------------------
        [ForeignKey("Codigo_Cliente")]
        public Cliente cliente { get; set; }
    }
}

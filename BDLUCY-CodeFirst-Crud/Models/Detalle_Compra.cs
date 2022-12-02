using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BDLUCY_CodeFirst_Crud.Models
{
    public class Detalle_Compra
    {

        [Key] //Atributo Clave
        public int Codigo_Detalle_Compra { get; set; }
        //----------------------------------------------
        public int Codigo_Compra { get; set; }          //ATRIBUTO RELACIONADO
        //----------------------------------------------
        public int Codigo_Paquete { get; set; }         //ATRIBUTO RELACIONADO
        //----------------------------------------------
        public int Cantidad { get; set; }
        //----------------------------------------------
        public float Precio_Unitario { get; set; }
        //----------------------------------------------
        public float Importe_Detalle_Compra { get; set; }
        //----------------------------------------------

        //ESTÁBLECEMOS LAS RELACIONES ENTRE CLASES
        //----------------------------------------------
        [ForeignKey("Codigo_Compra")]                  //ForeingKey
        public virtual Compra compra { get; set; }
        //----------------------------------------------
        [ForeignKey("Codigo_Paquete")]             //ForeingKey
        public virtual Paquete paquete { get; set; }
        //----------------------------------------------
    }
}

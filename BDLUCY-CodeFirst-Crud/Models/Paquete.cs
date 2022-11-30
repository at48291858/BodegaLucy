using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BDLUCY_CodeFirst_Crud.Models
{
    public class Paquete
    {
        [Key] //Atributo Clave
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo_Paquete { get; set; }
        //----------------------------------------------
        [Column(TypeName = "nvarchar(50)")]
        public string Nombre_Paquete { get; set; } = "";
        //----------------------------------------------
        public int Cantidad_Por_Paquete { get; set; }
        //----------------------------------------------
        [Column(TypeName = "nvarchar(10)")]
        public string Contenido_Por_Unidad { get; set; } = "";
        //----------------------------------------------
        [Column(TypeName = "nvarchar(70)")]
        public string Descripcion_Paquete { get; set; } = "";
        //----------------------------------------------

        public ICollection<Detalle_Compra> Detalle_Compras { get; set; }
    }

}

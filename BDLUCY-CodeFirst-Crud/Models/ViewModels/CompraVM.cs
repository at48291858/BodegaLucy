using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BDLUCY_CodeFirst_Crud.Models.ViewModels
{
    public class CompraVM
    {
        [Key] //Atributo Clave
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo_Detalle_Compra { get; set; }
        public Compra oCompra { get; set; } 
        public List<Detalle_Compra> oDetalle_compra { get; set; }

    }
}

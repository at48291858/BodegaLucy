using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BDLUCY_CodeFirst_Crud.Models
{
    public class Producto
    {
        [Key]
        public int Codigo_Producto { get; set; }
        [Required(ErrorMessage = "La subcategoria no ha sido seleccionada")]
        public int Codigo_Subcategoria { get; set; }  //Relacion
        [Required(ErrorMessage = "La presentacion no ha sido seleccionada")]
        public int Codigo_Presentacion { get; set; } //Relacion
        [Required(ErrorMessage = "La marca no ha sido seleccionada")]
        public int Codigo_Marca { get; set; }  //Relacion
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "El nombre no ha sido ingresado")]
        public string Nombre_Producto { get; set; }
        [Column(TypeName = "nvarchar(13)")]
        [Required(ErrorMessage = "El codigo de barra no ha sido ingresado")]
        public string Codigo_De_Barra { get; set; }
        public float Stock_Producto { get; set; } = 0;
        [Required(ErrorMessage = "El precio de compra no ha sido ingresado")]
        public float Precio_Compra_Producto { get; set; } = 0;
        [Required(ErrorMessage = "El precio de venta no ha sido ingresado")]
        public float Precio_Venta_Producto { get; set; } = 0;
        [Column(TypeName = "nvarchar(150)")]
        [MaxLength(150, ErrorMessage = "Solo se puede ingresar 150 caracteres")]
        public string? Descripcion_Producto { get; set; } = "";
        [Column(TypeName = "nvarchar(255)")]
        public string? NombreImage { get; set; } = "";

        [Column(TypeName = "nvarchar(80)")]
        [NotMapped] //Indica que el campo no sera migrado
        [DisplayName("Cargar Archivo Imagen")]
        public IFormFile? ArchivoImagen { get; set; }

        public bool Estado_Producto { get; set; }

        //Establecer las relaciones entre clases
        [ForeignKey("Codigo_Subcategoria")]
        public Subcategoria? subcategoria { get; set; }
        [ForeignKey("Codigo_Presentacion")]
        public Presentacion? presentacion { get; set; }
        [ForeignKey("Codigo_Marca")]
        public Marca? marca { get; set; }
    }
}

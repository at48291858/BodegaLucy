using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BDLUCY_CodeFirst_Crud.Models
{
    public class Usuario
    {
        [Key] //Atributo Clave
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo_Usuario { get; set; }
        //----------------------------------------------
        [Column(TypeName = "nvarchar(8)")]
        public string DNI_Usuario { get; set; } = "";
        //----------------------------------------------
        [Column(TypeName = "nvarchar(25)")]
        public string Nombre_Usuario { get; set; } = "";
        //----------------------------------------------
        [Column(TypeName = "nvarchar(15)")]
        public string Apellido_Paterno_Usuario { get; set; } = "";
        //----------------------------------------------
        [Column(TypeName = "nvarchar(15)")]
        public string Apellido_Materno_Usuario { get; set; } = "";
        //----------------------------------------------
        [Column(TypeName = "nvarchar(150)")]
        public string Direccion_Usuario { get; set; } = "";
        //----------------------------------------------
        [Column(TypeName = "nvarchar(30)")]
        public string Correo_Usuario { get; set; } = "";
        //----------------------------------------------
        [Column(TypeName = "nvarchar(9)")]
        public string Telefono_Usuario { get; set; } = "";
        //----------------------------------------------
        [Column(TypeName = "nvarchar(20)")]
        public string User_Usuario { get; set; } = "";
        //----------------------------------------------
        [Column(TypeName = "nvarchar(20)")]
        public string clave_Usuario { get; set; } = "";
        //----------------------------------------------
        [Column(TypeName = "nvarchar(30)")]
        public string Pregunta_Secreta { get; set; } = "";
        //----------------------------------------------
        [Column(TypeName = "nvarchar(20)")]
        public string Respuesta_Secreta { get; set; } = "";
        //----------------------------------------------
        public bool Estado_Usuario { get; set; }

        //---------------------- NUEVO CÓDIGO ----------------------
        public IEnumerable<Compra> Compras { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;

namespace BDLUCY_CodeFirst_Crud.Models
{
    public class BdLucyContext : DbContext
    {
        public BdLucyContext(DbContextOptions<BdLucyContext>
            options) : base(options) { }
        //Establecer las entidades que van a hacer migradas
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Incidencia> Incidencias { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Presentacion> Presentacions { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Subcategoria> Subcategorias { get; set; }
        //---------------------------------------------------
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }
        public DbSet<Distribuidor> Distribuidors{ get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Detalle_Venta> detalle_Ventas { get; set; }
        public DbSet<Detalle_Compra> Detalle_Compras { get; set; }
    }
}

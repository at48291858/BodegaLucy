﻿// <auto-generated />
using System;
using BDLUCY_CodeFirst_Crud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BDLUCY_CodeFirst_Crud.Migrations
{
    [DbContext(typeof(BdLucyContext))]
    [Migration("20221118194059_MBdLucyV4")]
    partial class MBdLucyV4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BDLUCY_CodeFirst_Crud.Models.Categoria", b =>
                {
                    b.Property<int>("Codigo_Categoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo_Categoria"), 1L, 1);

                    b.Property<string>("Descripcion_Categoria")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("Estado_Categoria")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre_Categoria")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Codigo_Categoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("BDLUCY_CodeFirst_Crud.Models.Cliente", b =>
                {
                    b.Property<int>("Codigo_Cliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo_Cliente"), 1L, 1);

                    b.Property<string>("Apellido_Materno_Cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Apellido_Paterno_Cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Documento_Cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Nombre_Cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Tipo_Documento_Cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("Codigo_Cliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("BDLUCY_CodeFirst_Crud.Models.Compra", b =>
                {
                    b.Property<int>("Codigo_Compra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo_Compra"), 1L, 1);

                    b.Property<int>("Codigo_Distribuidor")
                        .HasColumnType("int");

                    b.Property<int>("Codigo_Usuario")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha_Compra")
                        .HasColumnType("datetime2");

                    b.Property<float>("IGV_Compra")
                        .HasColumnType("real");

                    b.Property<string>("Numero_Comprobante_Compra")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Serie_Comprobante_Compra")
                        .IsRequired()
                        .HasColumnType("nvarchar(4)");

                    b.Property<float>("Subtotal_Compra")
                        .HasColumnType("real");

                    b.Property<string>("Tipo_Comprobante")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<float>("Total_Compra")
                        .HasColumnType("real");

                    b.HasKey("Codigo_Compra");

                    b.HasIndex("Codigo_Distribuidor");

                    b.HasIndex("Codigo_Usuario");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("BDLUCY_CodeFirst_Crud.Models.Detalle_Venta", b =>
                {
                    b.Property<int>("Codigo_Detalle_Venta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo_Detalle_Venta"), 1L, 1);

                    b.Property<int>("Cantidad_Detalle_Venta")
                        .HasColumnType("int");

                    b.Property<int>("Codigo_Producto")
                        .HasColumnType("int");

                    b.Property<int>("Codigo_Venta")
                        .HasColumnType("int");

                    b.Property<float>("Descuento_Detalle_Venta")
                        .HasColumnType("real");

                    b.Property<float>("Importe_Detalle_Venta")
                        .HasColumnType("real");

                    b.HasKey("Codigo_Detalle_Venta");

                    b.HasIndex("Codigo_Producto");

                    b.HasIndex("Codigo_Venta");

                    b.ToTable("detalle_Ventas");
                });

            modelBuilder.Entity("BDLUCY_CodeFirst_Crud.Models.Distribuidor", b =>
                {
                    b.Property<int>("Codigo_Distribuidor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo_Distribuidor"), 1L, 1);

                    b.Property<string>("Direccion_Distribuidor")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("Estado_Distribuidor")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre_Contacto")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("RUC_Distribuidor")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Razon_Social_Distribuidor")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono_Contacto")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Telefono_Distribuidor")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("Codigo_Distribuidor");

                    b.ToTable("Distribuidors");
                });

            modelBuilder.Entity("BDLUCY_CodeFirst_Crud.Models.Empresa", b =>
                {
                    b.Property<int>("Codigo_Empresa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo_Empresa"), 1L, 1);

                    b.Property<string>("Descripcion_Empresa")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Nombre_Empresa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Codigo_Empresa");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("BDLUCY_CodeFirst_Crud.Models.Incidencia", b =>
                {
                    b.Property<int>("Codigo_Incidencia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo_Incidencia"), 1L, 1);

                    b.Property<int>("Cantidad_Incidencia")
                        .HasColumnType("int");

                    b.Property<int>("Codigo_Producto")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion_Incidencia")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("Fecha_Incidencia")
                        .HasColumnType("datetime2");

                    b.HasKey("Codigo_Incidencia");

                    b.HasIndex("Codigo_Producto");

                    b.ToTable("Incidencias");
                });

            modelBuilder.Entity("BDLUCY_CodeFirst_Crud.Models.Marca", b =>
                {
                    b.Property<int>("Codigo_Marca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo_Marca"), 1L, 1);

                    b.Property<int>("Codigo_Empresa")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion_Marca")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Nombre_Marca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Codigo_Marca");

                    b.HasIndex("Codigo_Empresa");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("BDLUCY_CodeFirst_Crud.Models.Oferta", b =>
                {
                    b.Property<int>("Codigo_Oferta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo_Oferta"), 1L, 1);

                    b.Property<int>("Cantidad_Oferta")
                        .HasColumnType("int");

                    b.Property<int>("Codigo_Producto")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion_Oferta")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("Descuento_Oferta")
                        .HasColumnType("real");

                    b.Property<DateTime>("Fecha_Final_Oferta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_Inicio_Oferta")
                        .HasColumnType("datetime2");

                    b.HasKey("Codigo_Oferta");

                    b.HasIndex("Codigo_Producto");

                    b.ToTable("Ofertas");
                });

            modelBuilder.Entity("BDLUCY_CodeFirst_Crud.Models.Paquete", b =>
                {
                    b.Property<int>("Codigo_Paquete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo_Paquete"), 1L, 1);

                    b.Property<int>("Cantidad_Por_Paquete")
                        .HasColumnType("int");

                    b.Property<string>("Contenido_Por_Unidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Descripcion_Paquete")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Nombre_Paquete")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Codigo_Paquete");

                    b.ToTable("Paquetes");
                });

            modelBuilder.Entity("BDLUCY_CodeFirst_Crud.Models.Presentacion", b =>
                {
                    b.Property<int>("Codigo_Presentacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo_Presentacion"), 1L, 1);

                    b.Property<string>("Nombre_Presentacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Siglas_Presentacion")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("Codigo_Presentacion");

                    b.ToTable("Presentacions");
                });

            modelBuilder.Entity("BDLUCY_CodeFirst_Crud.Models.Producto", b =>
                {
                    b.Property<int>("Codigo_Producto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo_Producto"), 1L, 1);

                    b.Property<string>("Codigo_De_Barra")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("Codigo_Marca")
                        .HasColumnType("int");

                    b.Property<int>("Codigo_Presentacion")
                        .HasColumnType("int");

                    b.Property<int>("Codigo_Subcategoria")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion_Producto")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("Estado_Producto")
                        .HasColumnType("bit");

                    b.Property<string>("NombreImage")
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Nombre_Producto")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("Precio_Compra_Producto")
                        .HasColumnType("real");

                    b.Property<float>("Precio_Venta_Producto")
                        .HasColumnType("real");

                    b.Property<float>("Stock_Producto")
                        .HasColumnType("real");

                    b.HasKey("Codigo_Producto");

                    b.HasIndex("Codigo_Marca");

                    b.HasIndex("Codigo_Presentacion");

                    b.HasIndex("Codigo_Subcategoria");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("BDLUCY_CodeFirst_Crud.Models.Subcategoria", b =>
                {
                    b.Property<int>("Codigo_Subcategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo_Subcategoria"), 1L, 1);

                    b.Property<int>("Codigo_Categoria")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion_Subcategoria")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("Estado_Subcategoria")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre_Subcategoria")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Codigo_Subcategoria");

                    b.HasIndex("Codigo_Categoria");

                    b.ToTable("Subcategorias");
                });

            modelBuilder.Entity("BDLUCY_CodeFirst_Crud.Models.Usuario", b =>
                {
                    b.Property<int>("Codigo_Usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo_Usuario"), 1L, 1);

                    b.Property<string>("Apellido_Materno_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Apellido_Paterno_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Correo_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("DNI_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Direccion_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("Estado_Usuario")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Pregunta_Secreta")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Respuesta_Secreta")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Telefono_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("User_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("clave_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Codigo_Usuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("BDLUCY_CodeFirst_Crud.Models.Venta", b =>
                {
                    b.Property<int>("Codigo_Venta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo_Venta"), 1L, 1);

                    b.Property<int>("Codigo_Cliente")
                        .HasColumnType("int");

                    b.Property<int>("Codigo_Usuario")
                        .HasColumnType("int");

                    b.Property<float>("Descuento_Venta")
                        .HasColumnType("real");

                    b.Property<DateTime>("Fecha_Venta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Hora_Venta")
                        .HasColumnType("datetime2");

                    b.Property<float>("IGV_Venta")
                        .HasColumnType("real");

                    b.Property<float>("Monto_Total_Venta")
                        .HasColumnType("real");

                    b.Property<string>("Numero_Comprobante")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Serie_Comprobante_Venta")
                        .IsRequired()
                        .HasColumnType("nvarchar(4)");

                    b.Property<float>("Subtotal_Venta")
                        .HasColumnType("real");

                    b.Property<float>("Total_Venta")
                        .HasColumnType("real");

                    b.HasKey("Codigo_Venta");

                    b.HasIndex("Codigo_Cliente");

                    b.HasIndex("Codigo_Usuario");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("BDLUCY_CodeFirst_Crud.Models.Compra", b =>
                {
                    b.HasOne("BDLUCY_CodeFirst_Crud.Models.Distribuidor", "distribuidor")
                        .WithMany()
                        .HasForeignKey("Codigo_Distribuidor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BDLUCY_CodeFirst_Crud.Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("Codigo_Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("distribuidor");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("BDLUCY_CodeFirst_Crud.Models.Detalle_Venta", b =>
                {
                    b.HasOne("BDLUCY_CodeFirst_Crud.Models.Producto", "producto")
                        .WithMany()
                        .HasForeignKey("Codigo_Producto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BDLUCY_CodeFirst_Crud.Models.Venta", "venta")
                        .WithMany()
                        .HasForeignKey("Codigo_Venta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("producto");

                    b.Navigation("venta");
                });

            modelBuilder.Entity("BDLUCY_CodeFirst_Crud.Models.Incidencia", b =>
                {
                    b.HasOne("BDLUCY_CodeFirst_Crud.Models.Producto", "producto")
                        .WithMany()
                        .HasForeignKey("Codigo_Producto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("producto");
                });

            modelBuilder.Entity("BDLUCY_CodeFirst_Crud.Models.Marca", b =>
                {
                    b.HasOne("BDLUCY_CodeFirst_Crud.Models.Empresa", "empresa")
                        .WithMany()
                        .HasForeignKey("Codigo_Empresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("empresa");
                });

            modelBuilder.Entity("BDLUCY_CodeFirst_Crud.Models.Oferta", b =>
                {
                    b.HasOne("BDLUCY_CodeFirst_Crud.Models.Producto", "producto")
                        .WithMany()
                        .HasForeignKey("Codigo_Producto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("producto");
                });

            modelBuilder.Entity("BDLUCY_CodeFirst_Crud.Models.Producto", b =>
                {
                    b.HasOne("BDLUCY_CodeFirst_Crud.Models.Marca", "marca")
                        .WithMany()
                        .HasForeignKey("Codigo_Marca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BDLUCY_CodeFirst_Crud.Models.Presentacion", "presentacion")
                        .WithMany()
                        .HasForeignKey("Codigo_Presentacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BDLUCY_CodeFirst_Crud.Models.Subcategoria", "subcategoria")
                        .WithMany()
                        .HasForeignKey("Codigo_Subcategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("marca");

                    b.Navigation("presentacion");

                    b.Navigation("subcategoria");
                });

            modelBuilder.Entity("BDLUCY_CodeFirst_Crud.Models.Subcategoria", b =>
                {
                    b.HasOne("BDLUCY_CodeFirst_Crud.Models.Categoria", "categoria")
                        .WithMany()
                        .HasForeignKey("Codigo_Categoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categoria");
                });

            modelBuilder.Entity("BDLUCY_CodeFirst_Crud.Models.Venta", b =>
                {
                    b.HasOne("BDLUCY_CodeFirst_Crud.Models.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("Codigo_Cliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BDLUCY_CodeFirst_Crud.Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("Codigo_Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");

                    b.Navigation("usuario");
                });
#pragma warning restore 612, 618
        }
    }
}

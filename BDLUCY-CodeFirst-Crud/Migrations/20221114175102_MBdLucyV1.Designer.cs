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
    [Migration("20221114175102_MBdLucyV1")]
    partial class MBdLucyV1
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
#pragma warning restore 612, 618
        }
    }
}

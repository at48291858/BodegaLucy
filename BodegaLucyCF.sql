USE [BodegaLucyCF]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 21/11/2022 21:28:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 21/11/2022 21:28:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[Codigo_Categoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Categoria] [nvarchar](50) NOT NULL,
	[Descripcion_Categoria] [nvarchar](150) NULL,
	[Estado_Categoria] [bit] NOT NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[Codigo_Categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 21/11/2022 21:28:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Codigo_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Cliente] [nvarchar](25) NOT NULL,
	[Apellido_Paterno_Cliente] [nvarchar](20) NOT NULL,
	[Apellido_Materno_Cliente] [nvarchar](20) NOT NULL,
	[Tipo_Documento_Cliente] [nvarchar](3) NOT NULL,
	[Documento_Cliente] [nvarchar](13) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Codigo_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compras]    Script Date: 21/11/2022 21:28:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compras](
	[Codigo_Compra] [int] IDENTITY(1,1) NOT NULL,
	[Fecha_Compra] [datetime2](7) NOT NULL,
	[Tipo_Comprobante] [nvarchar](10) NOT NULL,
	[Serie_Comprobante_Compra] [nvarchar](4) NOT NULL,
	[Numero_Comprobante_Compra] [nvarchar](8) NOT NULL,
	[Codigo_Usuario] [int] NOT NULL,
	[Codigo_Distribuidor] [int] NOT NULL,
	[IGV_Compra] [real] NOT NULL,
	[Subtotal_Compra] [real] NOT NULL,
	[Total_Compra] [real] NOT NULL,
 CONSTRAINT [PK_Compras] PRIMARY KEY CLUSTERED 
(
	[Codigo_Compra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_Compras]    Script Date: 21/11/2022 21:28:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Compras](
	[Codigo_Detalle_Compra] [int] IDENTITY(1,1) NOT NULL,
	[Codigo_Compra] [int] NOT NULL,
	[Codigo_Paquete] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio_Unitario] [real] NOT NULL,
	[Importe_Detalle_Compra] [real] NOT NULL,
 CONSTRAINT [PK_Detalle_Compras] PRIMARY KEY CLUSTERED 
(
	[Codigo_Detalle_Compra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_Ventas]    Script Date: 21/11/2022 21:28:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_Ventas](
	[Codigo_Detalle_Venta] [int] IDENTITY(1,1) NOT NULL,
	[Codigo_Producto] [int] NOT NULL,
	[Codigo_Venta] [int] NOT NULL,
	[Cantidad_Detalle_Venta] [int] NOT NULL,
	[Importe_Detalle_Venta] [real] NOT NULL,
	[Descuento_Detalle_Venta] [real] NOT NULL,
 CONSTRAINT [PK_detalle_Ventas] PRIMARY KEY CLUSTERED 
(
	[Codigo_Detalle_Venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Distribuidors]    Script Date: 21/11/2022 21:28:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distribuidors](
	[Codigo_Distribuidor] [int] IDENTITY(1,1) NOT NULL,
	[Razon_Social_Distribuidor] [nvarchar](50) NOT NULL,
	[RUC_Distribuidor] [nvarchar](11) NOT NULL,
	[Direccion_Distribuidor] [nvarchar](150) NOT NULL,
	[Telefono_Distribuidor] [nvarchar](9) NOT NULL,
	[Nombre_Contacto] [nvarchar](70) NOT NULL,
	[Telefono_Contacto] [nvarchar](70) NOT NULL,
	[Estado_Distribuidor] [bit] NOT NULL,
 CONSTRAINT [PK_Distribuidors] PRIMARY KEY CLUSTERED 
(
	[Codigo_Distribuidor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresas]    Script Date: 21/11/2022 21:28:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresas](
	[Codigo_Empresa] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Empresa] [nvarchar](50) NOT NULL,
	[Descripcion_Empresa] [nvarchar](150) NULL,
 CONSTRAINT [PK_Empresas] PRIMARY KEY CLUSTERED 
(
	[Codigo_Empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Incidencias]    Script Date: 21/11/2022 21:28:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incidencias](
	[Codigo_Incidencia] [int] IDENTITY(1,1) NOT NULL,
	[Codigo_Producto] [int] NOT NULL,
	[Descripcion_Incidencia] [nvarchar](150) NOT NULL,
	[Cantidad_Incidencia] [int] NOT NULL,
	[Fecha_Incidencia] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Incidencias] PRIMARY KEY CLUSTERED 
(
	[Codigo_Incidencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 21/11/2022 21:28:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[Codigo_Marca] [int] IDENTITY(1,1) NOT NULL,
	[Codigo_Empresa] [int] NOT NULL,
	[Nombre_Marca] [nvarchar](50) NOT NULL,
	[Descripcion_Marca] [nvarchar](150) NULL,
 CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED 
(
	[Codigo_Marca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ofertas]    Script Date: 21/11/2022 21:28:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ofertas](
	[Codigo_Oferta] [int] IDENTITY(1,1) NOT NULL,
	[Codigo_Producto] [int] NOT NULL,
	[Cantidad_Oferta] [int] NOT NULL,
	[Descuento_Oferta] [real] NOT NULL,
	[Descripcion_Oferta] [nvarchar](100) NOT NULL,
	[Fecha_Inicio_Oferta] [datetime2](7) NOT NULL,
	[Fecha_Final_Oferta] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Ofertas] PRIMARY KEY CLUSTERED 
(
	[Codigo_Oferta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paquetes]    Script Date: 21/11/2022 21:28:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paquetes](
	[Codigo_Paquete] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Paquete] [nvarchar](50) NOT NULL,
	[Cantidad_Por_Paquete] [int] NOT NULL,
	[Contenido_Por_Unidad] [nvarchar](10) NOT NULL,
	[Descripcion_Paquete] [nvarchar](70) NOT NULL,
 CONSTRAINT [PK_Paquetes] PRIMARY KEY CLUSTERED 
(
	[Codigo_Paquete] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Presentacions]    Script Date: 21/11/2022 21:28:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presentacions](
	[Codigo_Presentacion] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Presentacion] [nvarchar](50) NOT NULL,
	[Siglas_Presentacion] [nvarchar](3) NOT NULL,
 CONSTRAINT [PK_Presentacions] PRIMARY KEY CLUSTERED 
(
	[Codigo_Presentacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 21/11/2022 21:28:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Codigo_Producto] [int] IDENTITY(1,1) NOT NULL,
	[Codigo_Subcategoria] [int] NOT NULL,
	[Codigo_Presentacion] [int] NOT NULL,
	[Codigo_Marca] [int] NOT NULL,
	[Nombre_Producto] [nvarchar](50) NOT NULL,
	[Codigo_De_Barra] [nvarchar](13) NOT NULL,
	[Stock_Producto] [real] NOT NULL,
	[Precio_Compra_Producto] [real] NOT NULL,
	[Precio_Venta_Producto] [real] NOT NULL,
	[Descripcion_Producto] [nvarchar](150) NULL,
	[NombreImage] [nvarchar](80) NULL,
	[Estado_Producto] [bit] NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[Codigo_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subcategorias]    Script Date: 21/11/2022 21:28:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subcategorias](
	[Codigo_Subcategoria] [int] IDENTITY(1,1) NOT NULL,
	[Codigo_Categoria] [int] NOT NULL,
	[Nombre_Subcategoria] [nvarchar](50) NOT NULL,
	[Descripcion_Subcategoria] [nvarchar](150) NULL,
	[Estado_Subcategoria] [bit] NOT NULL,
 CONSTRAINT [PK_Subcategorias] PRIMARY KEY CLUSTERED 
(
	[Codigo_Subcategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 21/11/2022 21:28:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Codigo_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[DNI_Usuario] [nvarchar](8) NOT NULL,
	[Nombre_Usuario] [nvarchar](25) NOT NULL,
	[Apellido_Paterno_Usuario] [nvarchar](15) NOT NULL,
	[Apellido_Materno_Usuario] [nvarchar](15) NOT NULL,
	[Direccion_Usuario] [nvarchar](150) NOT NULL,
	[Correo_Usuario] [nvarchar](30) NOT NULL,
	[Telefono_Usuario] [nvarchar](9) NOT NULL,
	[User_Usuario] [nvarchar](20) NOT NULL,
	[clave_Usuario] [nvarchar](20) NOT NULL,
	[Pregunta_Secreta] [nvarchar](30) NOT NULL,
	[Respuesta_Secreta] [nvarchar](20) NOT NULL,
	[Estado_Usuario] [bit] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Codigo_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 21/11/2022 21:28:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[Codigo_Venta] [int] IDENTITY(1,1) NOT NULL,
	[Serie_Comprobante_Venta] [nvarchar](4) NOT NULL,
	[Numero_Comprobante] [nvarchar](20) NOT NULL,
	[Fecha_Venta] [datetime2](7) NOT NULL,
	[Hora_Venta] [datetime2](7) NOT NULL,
	[Monto_Total_Venta] [real] NOT NULL,
	[Codigo_Usuario] [int] NOT NULL,
	[Codigo_Cliente] [int] NOT NULL,
	[Subtotal_Venta] [real] NOT NULL,
	[Descuento_Venta] [real] NOT NULL,
	[IGV_Venta] [real] NOT NULL,
	[Total_Venta] [real] NOT NULL,
 CONSTRAINT [PK_Ventas] PRIMARY KEY CLUSTERED 
(
	[Codigo_Venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Distribuidors_Codigo_Distribuidor] FOREIGN KEY([Codigo_Distribuidor])
REFERENCES [dbo].[Distribuidors] ([Codigo_Distribuidor])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_Distribuidors_Codigo_Distribuidor]
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Usuarios_Codigo_Usuario] FOREIGN KEY([Codigo_Usuario])
REFERENCES [dbo].[Usuarios] ([Codigo_Usuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_Usuarios_Codigo_Usuario]
GO
ALTER TABLE [dbo].[Detalle_Compras]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Compras_Compras_Codigo_Compra] FOREIGN KEY([Codigo_Compra])
REFERENCES [dbo].[Compras] ([Codigo_Compra])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Detalle_Compras] CHECK CONSTRAINT [FK_Detalle_Compras_Compras_Codigo_Compra]
GO
ALTER TABLE [dbo].[Detalle_Compras]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Compras_Paquetes_Codigo_Paquete] FOREIGN KEY([Codigo_Paquete])
REFERENCES [dbo].[Paquetes] ([Codigo_Paquete])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Detalle_Compras] CHECK CONSTRAINT [FK_Detalle_Compras_Paquetes_Codigo_Paquete]
GO
ALTER TABLE [dbo].[detalle_Ventas]  WITH CHECK ADD  CONSTRAINT [FK_detalle_Ventas_Productos_Codigo_Producto] FOREIGN KEY([Codigo_Producto])
REFERENCES [dbo].[Productos] ([Codigo_Producto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalle_Ventas] CHECK CONSTRAINT [FK_detalle_Ventas_Productos_Codigo_Producto]
GO
ALTER TABLE [dbo].[detalle_Ventas]  WITH CHECK ADD  CONSTRAINT [FK_detalle_Ventas_Ventas_Codigo_Venta] FOREIGN KEY([Codigo_Venta])
REFERENCES [dbo].[Ventas] ([Codigo_Venta])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalle_Ventas] CHECK CONSTRAINT [FK_detalle_Ventas_Ventas_Codigo_Venta]
GO
ALTER TABLE [dbo].[Incidencias]  WITH CHECK ADD  CONSTRAINT [FK_Incidencias_Productos_Codigo_Producto] FOREIGN KEY([Codigo_Producto])
REFERENCES [dbo].[Productos] ([Codigo_Producto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Incidencias] CHECK CONSTRAINT [FK_Incidencias_Productos_Codigo_Producto]
GO
ALTER TABLE [dbo].[Marcas]  WITH CHECK ADD  CONSTRAINT [FK_Marcas_Empresas_Codigo_Empresa] FOREIGN KEY([Codigo_Empresa])
REFERENCES [dbo].[Empresas] ([Codigo_Empresa])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Marcas] CHECK CONSTRAINT [FK_Marcas_Empresas_Codigo_Empresa]
GO
ALTER TABLE [dbo].[Ofertas]  WITH CHECK ADD  CONSTRAINT [FK_Ofertas_Productos_Codigo_Producto] FOREIGN KEY([Codigo_Producto])
REFERENCES [dbo].[Productos] ([Codigo_Producto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ofertas] CHECK CONSTRAINT [FK_Ofertas_Productos_Codigo_Producto]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Marcas_Codigo_Marca] FOREIGN KEY([Codigo_Marca])
REFERENCES [dbo].[Marcas] ([Codigo_Marca])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Marcas_Codigo_Marca]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Presentacions_Codigo_Presentacion] FOREIGN KEY([Codigo_Presentacion])
REFERENCES [dbo].[Presentacions] ([Codigo_Presentacion])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Presentacions_Codigo_Presentacion]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Subcategorias_Codigo_Subcategoria] FOREIGN KEY([Codigo_Subcategoria])
REFERENCES [dbo].[Subcategorias] ([Codigo_Subcategoria])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Subcategorias_Codigo_Subcategoria]
GO
ALTER TABLE [dbo].[Subcategorias]  WITH CHECK ADD  CONSTRAINT [FK_Subcategorias_Categorias_Codigo_Categoria] FOREIGN KEY([Codigo_Categoria])
REFERENCES [dbo].[Categorias] ([Codigo_Categoria])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Subcategorias] CHECK CONSTRAINT [FK_Subcategorias_Categorias_Codigo_Categoria]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_Clientes_Codigo_Cliente] FOREIGN KEY([Codigo_Cliente])
REFERENCES [dbo].[Clientes] ([Codigo_Cliente])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_Clientes_Codigo_Cliente]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_Usuarios_Codigo_Usuario] FOREIGN KEY([Codigo_Usuario])
REFERENCES [dbo].[Usuarios] ([Codigo_Usuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_Usuarios_Codigo_Usuario]
GO

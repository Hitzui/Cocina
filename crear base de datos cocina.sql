USE [master]
GO
/****** Object:  Database [cocina]    Script Date: 11/10/2015 10:00:28 p.m. ******/
CREATE DATABASE [cocina]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'cocina', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SERVIDOR\MSSQL\DATA\cocina.mdf' , SIZE = 13312KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'cocina_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SERVIDOR\MSSQL\DATA\cocina_log.ldf' , SIZE = 35712KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [cocina] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [cocina].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [cocina] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [cocina] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [cocina] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [cocina] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [cocina] SET ARITHABORT OFF 
GO
ALTER DATABASE [cocina] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [cocina] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [cocina] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [cocina] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [cocina] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [cocina] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [cocina] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [cocina] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [cocina] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [cocina] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [cocina] SET  DISABLE_BROKER 
GO
ALTER DATABASE [cocina] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [cocina] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [cocina] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [cocina] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [cocina] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [cocina] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [cocina] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [cocina] SET RECOVERY FULL 
GO
ALTER DATABASE [cocina] SET  MULTI_USER 
GO
ALTER DATABASE [cocina] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [cocina] SET DB_CHAINING OFF 
GO
ALTER DATABASE [cocina] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [cocina] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'cocina', N'ON'
GO
USE [cocina]
GO
/****** Object:  StoredProcedure [dbo].[actIdFact]    Script Date: 11/10/2015 10:00:28 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[actIdFact]
as
	update IdTablas
	set IdCompra = IdCompra +1

GO
/****** Object:  StoredProcedure [dbo].[actIdRemision]    Script Date: 11/10/2015 10:00:28 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[actIdRemision]
as
	update IdTablas
	set IdRemision = IdRemision+1

GO
/****** Object:  StoredProcedure [dbo].[FiltrarBodega]    Script Date: 11/10/2015 10:00:28 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FiltrarBodega]
@Nombre varchar(100)
AS
BEGIN
select * from Bodegas
where Nombre like '%' + @Nombre + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[FiltrarCategoria]    Script Date: 11/10/2015 10:00:28 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FiltrarCategoria]
@Descripcion varchar(100)
AS
BEGIN
	select * from Categoria 
	where Descripcion like '%' + @Descripcion + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[filtrarGrupo]    Script Date: 11/10/2015 10:00:28 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[filtrarGrupo]
@Nombre varchar(100)
AS
select * from Grupo
where Descripcion like '%' + @Nombre + '%'

GO
/****** Object:  StoredProcedure [dbo].[FiltrarProducto]    Script Date: 11/10/2015 10:00:28 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FiltrarProducto]
@Nombre varchar(100)

AS
BEGIN
	select * from Productos
	where Nombre like '%' + @Nombre +'%'
END

GO
/****** Object:  StoredProcedure [dbo].[FiltrarProveedor]    Script Date: 11/10/2015 10:00:28 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[FiltrarProveedor]
@Nombre varchar(50)
as
select * from Proveedor
where Nombre like '%' + @Nombre+'%'

GO
/****** Object:  StoredProcedure [dbo].[FiltrarSucursal]    Script Date: 11/10/2015 10:00:28 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FiltrarSucursal]
@Nombre varchar(100)
AS
BEGIN
select * from Sucursal
where Nombre like '%' + @Nombre + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[insertarDetaCompra]    Script Date: 11/10/2015 10:00:28 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insertarDetaCompra]
@Codigo varchar(20),
@Nombre varchar(100),
@Cantidad numeric(12, 2),
@UnidadM varchar(10),
@PrecioC numeric(12, 2),
@Consecutivo int,
@Fecha date,
@IdCategoria varchar(20),
@IdGrupo varchar(20),
@NumFact varchar(20),
@IdProveedor int
as
INSERT INTO [dbo].[DetalleCompra]
           ([Codigo]
           ,[Nombre]
           ,[Cantidad]
           ,[UnidadM]
           ,[PrecioC]
		   ,[Consecutivo]
           ,[Fecha]
           ,[IdCategoria]
           ,[IdGrupo]
           ,[NumFactura]
           ,[IdProveedor])
VALUES
           (@Codigo,@Nombre,@Cantidad,@UnidadM,@PrecioC,@Consecutivo,@Fecha,@IdCategoria,
           @IdGrupo,@NumFact,@IdProveedor)

GO
/****** Object:  StoredProcedure [dbo].[insertDetaBodega]    Script Date: 11/10/2015 10:00:28 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertDetaBodega]
@CodProducto varchar(20),
@IdBodega int,
@Existencia numeric(12,2)
as
insert into DetaBodega values(@CodProducto, @IdBodega, @Existencia)

GO
/****** Object:  Table [dbo].[Bodegas]    Script Date: 11/10/2015 10:00:28 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bodegas](
	[IdBodega] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Bodegas] PRIMARY KEY CLUSTERED 
(
	[IdBodega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 11/10/2015 10:00:29 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [varchar](20) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[IdGrupo] [varchar](20) NOT NULL,
	[NextIdProd] [int] NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 11/10/2015 10:00:29 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Compra](
	[NumFac] [varchar](20) NOT NULL,
	[Fecha] [date] NOT NULL,
	[Total] [numeric](12, 3) NOT NULL,
	[IdProveedor] [int] NULL,
	[Iva] [numeric](12, 3) NULL,
	[referencia] [varchar](50) NULL,
 CONSTRAINT [PK_Compra] PRIMARY KEY CLUSTERED 
(
	[NumFac] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetaBodega]    Script Date: 11/10/2015 10:00:29 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DetaBodega](
	[CodProducto] [varchar](20) NOT NULL,
	[IdBodega] [int] NOT NULL,
	[Existencia] [numeric](12, 3) NOT NULL,
 CONSTRAINT [PK_DetaBodega_1] PRIMARY KEY CLUSTERED 
(
	[CodProducto] ASC,
	[IdBodega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetalleCompra]    Script Date: 11/10/2015 10:00:29 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DetalleCompra](
	[NumFactura] [varchar](20) NOT NULL,
	[Consecutivo] [int] NOT NULL,
	[Codigo] [varchar](20) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Cantidad] [numeric](12, 3) NOT NULL,
	[UnidadM] [varchar](10) NOT NULL,
	[PrecioC] [numeric](12, 3) NOT NULL,
	[Fecha] [date] NULL,
	[IdCategoria] [varchar](20) NULL,
	[IdGrupo] [varchar](20) NULL,
	[IdProveedor] [int] NULL,
 CONSTRAINT [PK_DetalleCompra] PRIMARY KEY CLUSTERED 
(
	[Consecutivo] ASC,
	[NumFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetaRemision]    Script Date: 11/10/2015 10:00:29 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DetaRemision](
	[IdRemision] [varchar](50) NOT NULL,
	[CodProducto] [varchar](20) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Cantidad] [numeric](18, 3) NOT NULL,
	[Fecha] [date] NOT NULL,
 CONSTRAINT [PK_DetaRemision_1] PRIMARY KEY CLUSTERED 
(
	[IdRemision] ASC,
	[CodProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Grupo]    Script Date: 11/10/2015 10:00:29 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grupo](
	[IdGrupo] [varchar](20) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Grupo] PRIMARY KEY CLUSTERED 
(
	[IdGrupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IdTablas]    Script Date: 11/10/2015 10:00:29 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdTablas](
	[IdCompra] [int] NOT NULL,
	[IdRemision] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kardex]    Script Date: 11/10/2015 10:00:29 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Kardex](
	[CodProducto] [varchar](20) NOT NULL,
	[Fecha] [date] NOT NULL,
	[Inicial] [numeric](12, 3) NOT NULL,
	[Entrada] [numeric](12, 3) NOT NULL,
	[Salida] [numeric](12, 3) NOT NULL,
	[Balance] [numeric](12, 3) NOT NULL,
	[IdBodega] [int] NOT NULL,
	[Referencia] [varchar](50) NULL,
	[IdKardex] [int] IDENTITY(1,1) NOT NULL,
	[Costo] [numeric](12, 3) NULL,
 CONSTRAINT [PK_Kardex] PRIMARY KEY CLUSTERED 
(
	[IdKardex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 11/10/2015 10:00:29 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Productos](
	[CodProducto] [varchar](20) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[IdUnidad] [int] NOT NULL,
	[IdGrupo] [varchar](20) NOT NULL,
	[IdCategoria] [varchar](20) NOT NULL,
	[UltPrecioC] [numeric](12, 3) NULL,
	[Costo] [numeric](12, 3) NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[CodProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 11/10/2015 10:00:29 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proveedor](
	[IdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[NumRuc] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[FCrea] [date] NULL,
	[Direccion] [varchar](200) NULL,
	[Telefono] [varchar](20) NULL,
	[Codigo] [varchar](10) NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Remision]    Script Date: 11/10/2015 10:00:29 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Remision](
	[IdRemision] [varchar](50) NOT NULL,
	[Fecha] [date] NULL,
	[IdSucursal] [int] NULL,
	[Observacion] [text] NULL,
 CONSTRAINT [PK_Remision] PRIMARY KEY CLUSTERED 
(
	[IdRemision] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Remision2]    Script Date: 11/10/2015 10:00:29 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Remision2](
	[Codproducto] [varchar](20) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Enviado] [numeric](12, 2) NOT NULL,
	[Consecutivo] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Numremsion] [varchar](20) NULL,
	[UnidadM] [varchar](10) NULL,
 CONSTRAINT [PK_Remision2] PRIMARY KEY CLUSTERED 
(
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 11/10/2015 10:00:29 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sucursal](
	[IdSucursal] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Telefono] [varchar](20) NULL,
	[Direccion] [varchar](100) NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Unidad]    Script Date: 11/10/2015 10:00:29 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Unidad](
	[IdUnidad] [int] IDENTITY(1,1) NOT NULL,
	[UdidadM] [varchar](50) NULL,
	[Descripcion] [varchar](100) NULL,
 CONSTRAINT [PK_Unidad] PRIMARY KEY CLUSTERED 
(
	[IdUnidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 11/10/2015 10:00:29 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuairo] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Clave] [varchar](20) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Nivel] [int] NOT NULL,
	[FCrea] [date] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuairo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[ViewRemision]    Script Date: 11/10/2015 10:00:29 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewRemision]
AS
SELECT        dbo.Grupo.Descripcion AS Grupo, dbo.DetaRemision.IdUnidadM, dbo.Categoria.Descripcion AS Categoria, dbo.DetaRemision.Nombre, 
                         SUM(dbo.DetaRemision.Cantidad) AS Cantidad, MAX(dbo.DetaRemision.Precio) AS PUnt, SUM(dbo.Productos.Costo * dbo.DetaRemision.Cantidad) AS Valor, 
                         dbo.Sucursal.Nombre AS Sucursal, dbo.DetaRemision.Fecha
FROM            dbo.DetaRemision INNER JOIN
                         dbo.Grupo ON dbo.DetaRemision.IdGrupo = dbo.Grupo.IdGrupo INNER JOIN
                         dbo.Categoria ON dbo.DetaRemision.IdCategoria = dbo.Categoria.IdCategoria INNER JOIN
                         dbo.Sucursal ON dbo.DetaRemision.IdSucursal = dbo.Sucursal.IdSucursal INNER JOIN
                         dbo.Productos ON dbo.DetaRemision.CodProducto = dbo.Productos.CodProducto
GROUP BY dbo.Grupo.Descripcion, dbo.Categoria.Descripcion, dbo.Productos.CodProducto, dbo.DetaRemision.Nombre, dbo.Sucursal.Nombre, dbo.DetaRemision.IdUnidadM, 
                         dbo.DetaRemision.Fecha

GO
/****** Object:  View [dbo].[VistaProd]    Script Date: 11/10/2015 10:00:29 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VistaProd]
AS
SELECT        dbo.Productos.CodProducto, dbo.Productos.Nombre, dbo.Unidad.UdidadM, dbo.Productos.Costo, dbo.Bodegas.Nombre AS Bodega, dbo.DetaBodega.Existencia, 
                         dbo.DetaBodega.Existencia * dbo.Productos.Costo AS Total
FROM            dbo.Productos INNER JOIN
                         dbo.DetaBodega ON dbo.Productos.CodProducto = dbo.DetaBodega.CodProducto INNER JOIN
                         dbo.Unidad ON dbo.Productos.IdUnidad = dbo.Unidad.IdUnidad INNER JOIN
                         dbo.Bodegas ON dbo.DetaBodega.IdBodega = dbo.Bodegas.IdBodega

GO
ALTER TABLE [dbo].[DetalleCompra] ADD  CONSTRAINT [DF_DetalleCompra_Codigo]  DEFAULT ('(No existe)') FOR [Codigo]
GO
ALTER TABLE [dbo].[Remision] ADD  CONSTRAINT [DF_Remision_Observacion]  DEFAULT ('(Sin observaciones)') FOR [Observacion]
GO
ALTER TABLE [dbo].[Compra]  WITH NOCHECK ADD  CONSTRAINT [FK_Compra_Proveedor] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([IdProveedor])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Compra_Proveedor]
GO
ALTER TABLE [dbo].[DetalleCompra]  WITH NOCHECK ADD  CONSTRAINT [FK_DetalleCompra_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[DetalleCompra] CHECK CONSTRAINT [FK_DetalleCompra_Categoria]
GO
ALTER TABLE [dbo].[DetalleCompra]  WITH NOCHECK ADD  CONSTRAINT [FK_DetalleCompra_Grupo] FOREIGN KEY([IdGrupo])
REFERENCES [dbo].[Grupo] ([IdGrupo])
GO
ALTER TABLE [dbo].[DetalleCompra] CHECK CONSTRAINT [FK_DetalleCompra_Grupo]
GO
ALTER TABLE [dbo].[DetalleCompra]  WITH NOCHECK ADD  CONSTRAINT [FK_DetalleCompra_Productos] FOREIGN KEY([Codigo])
REFERENCES [dbo].[Productos] ([CodProducto])
ON UPDATE CASCADE
ON DELETE SET DEFAULT
GO
ALTER TABLE [dbo].[DetalleCompra] CHECK CONSTRAINT [FK_DetalleCompra_Productos]
GO
ALTER TABLE [dbo].[DetalleCompra]  WITH NOCHECK ADD  CONSTRAINT [FK_DetalleCompra_Proveedor] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([IdProveedor])
GO
ALTER TABLE [dbo].[DetalleCompra] CHECK CONSTRAINT [FK_DetalleCompra_Proveedor]
GO
ALTER TABLE [dbo].[DetaRemision]  WITH NOCHECK ADD  CONSTRAINT [FK_DetaRemision_Productos] FOREIGN KEY([CodProducto])
REFERENCES [dbo].[Productos] ([CodProducto])
GO
ALTER TABLE [dbo].[DetaRemision] CHECK CONSTRAINT [FK_DetaRemision_Productos]
GO
ALTER TABLE [dbo].[Kardex]  WITH NOCHECK ADD  CONSTRAINT [FK_Kardex_Bodegas] FOREIGN KEY([IdBodega])
REFERENCES [dbo].[Bodegas] ([IdBodega])
GO
ALTER TABLE [dbo].[Kardex] CHECK CONSTRAINT [FK_Kardex_Bodegas]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[16] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "DetaRemision"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 281
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Grupo"
            Begin Extent = 
               Top = 6
               Left = 285
               Bottom = 104
               Right = 510
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Categoria"
            Begin Extent = 
               Top = 6
               Left = 548
               Bottom = 135
               Right = 773
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Sucursal"
            Begin Extent = 
               Top = 102
               Left = 285
               Bottom = 231
               Right = 510
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Productos"
            Begin Extent = 
               Top = 138
               Left = 548
               Bottom = 313
               Right = 773
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 13
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 2535
         Width = 1500
         Width = 1530
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin Cr' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewRemision'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'iteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewRemision'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewRemision'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Productos"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 215
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DetaBodega"
            Begin Extent = 
               Top = 6
               Left = 285
               Bottom = 204
               Right = 494
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Unidad"
            Begin Extent = 
               Top = 6
               Left = 532
               Bottom = 118
               Right = 741
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Bodegas"
            Begin Extent = 
               Top = 120
               Left = 532
               Bottom = 224
               Right = 741
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1125
         Or = 1350
         Or = 1350
      End' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaProd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaProd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaProd'
GO
USE [master]
GO
ALTER DATABASE [cocina] SET  READ_WRITE 
GO

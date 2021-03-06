USE [cocina]
GO
/****** Object:  StoredProcedure [dbo].[insertarDetaCompra]    Script Date: 11/10/2015 18:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[insertarDetaCompra]
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

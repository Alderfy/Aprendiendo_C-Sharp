USE [xSolucionesDB]
GO

/****** Object:  StoredProcedure [dbo].[createSuplidor]    Script Date: 6/10/2020 7:10:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[createSuplidor]
@Nombre varchar(25), @RNC varchar(11), @Direccion varchar(100), @Representante varchar(25)
AS
INSERT INTO Suplidor(Nombre, RNC, Direccion, Representante, Borrado, fechaRegistro) VALUES(@Nombre, @RNC, @Direccion, @Representante, 0, GETDATE())
GO


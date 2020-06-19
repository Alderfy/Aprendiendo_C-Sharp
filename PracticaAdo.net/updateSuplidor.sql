USE [xSolucionesDB]
GO

/****** Object:  StoredProcedure [dbo].[updateSuplidor]    Script Date: 6/10/2020 7:11:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[updateSuplidor]
@RNC varchar(11), @Direccion varchar(100), @Representante varchar(25)
AS
UPDATE Suplidor SET Direccion = @Direccion, Representante = @Representante WHERE RNC = @RNC AND Borrado=0
GO


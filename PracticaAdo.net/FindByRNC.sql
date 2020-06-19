USE [xSolucionesDB]
GO

/****** Object:  StoredProcedure [dbo].[FindByRNC]    Script Date: 6/10/2020 7:10:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FindByRNC]
@RNC varchar(11)
AS
SELECT Nombre, RNC, Representante, fechaRegistro FROM Suplidor WHERE Borrado=0 AND RNC = @RNC
GO


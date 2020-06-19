USE [xSolucionesDB]
GO

/****** Object:  StoredProcedure [dbo].[GetAll]    Script Date: 6/10/2020 7:10:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAll]
as
SELECT Nombre, RNC, Representante, fechaRegistro FROM Suplidor WHERE Borrado=0
GO


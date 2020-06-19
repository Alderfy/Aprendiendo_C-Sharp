USE [xSolucionesDB]
GO

/****** Object:  StoredProcedure [dbo].[SoftDelete]    Script Date: 6/10/2020 7:11:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SoftDelete]
@RNC varchar(11)
AS
UPDATE Suplidor SET Borrado = 1 WHERE RNC = @RNC
GO


CREATE DATABASE sParcial

USE sParcial

CREATE TABLE Empleado
(
	ID int identity(1,1)
	, Nombre VARCHAR(100)
	, Departamento VARCHAR(50)
	, Sexo CHAR
	, fechaNacimiento DATE
	, sueldoBruto MONEY
	, sueldoImponible AS sueldoBruto - (sueldoBruto * 0.0591)
	, ISR AS
		CASE 
			WHEN (sueldoBruto-(sueldoBruto*0.0591))*12 <= 416220.00 THEN 0
			WHEN (sueldoBruto-(sueldoBruto*0.0591))*12 >= 416220.01 AND (sueldoBruto-(sueldoBruto*0.0591))*12 <= 624329.00 THEN ((((sueldoBruto-(sueldoBruto*0.0591))*12)-416220.01)*0.15)/12
			WHEN (sueldoBruto-(sueldoBruto*0.0591))*12 >= 624329.01 AND (sueldoBruto-(sueldoBruto*0.0591))*12 <= 867123.00 THEN (31216.00+(((sueldoBruto-(sueldoBruto*0.0591))*12)-624329.01)*0.20)/12
			WHEN (sueldoBruto-(sueldoBruto*0.0591))*12 >= 867123.01 THEN (79776.00+(((sueldoBruto-(sueldoBruto*0.0591))*12)-867123.01)*0.25)/12
		END
)
Go

CREATE PROCEDURE Nomina
AS
SELECT 
	Nombre,
	Departamento,
	Sexo,
	DATEDIFF(year, fechaNacimiento, GETDATE()) AS Edad,
	sueldoBruto,
	sueldoBruto * 0.0287 AS AFP,
	sueldoBruto * 0.0304 AS ARS,
	ISR,
	CASE 
		WHEN (sueldoBruto-(sueldoBruto*0.0591))*12 <= 416220.00 THEN 'Exento'
		WHEN (sueldoBruto-(sueldoBruto*0.0591))*12 >= 416220.01 AND (sueldoBruto-(sueldoBruto*0.0591))*12 <= 624329.00 THEN 'Escala 1'
		WHEN (sueldoBruto-(sueldoBruto*0.0591))*12 >= 624329.01 AND (sueldoBruto-(sueldoBruto*0.0591))*12 <= 867123.00 THEN 'Escala 2'
		WHEN (sueldoBruto-(sueldoBruto*0.0591))*12 >= 867123.01 THEN 'Escala 3'
	END AS escalaISR,
	sueldoImponible,
	sueldoBruto * 0.0591 + ISR AS totalRetenciones,
	sueldoBruto - ((sueldoBruto * 0.0591) + ISR) AS sueldoNeto
FROM Empleado
GO

EXEC Nomina
SELECT * FROM Empleado
create database pParcial

use pParcial

create table Empleado
(
	ID int identity(1,1)
	, Nombre varchar(25)
	, Apellido varchar(25)
	, Cedula varchar(11)
	, sueldoBruto MONEY
	, sueldoNeto AS sueldoBruto - ((sueldoBruto * 0.0287) + (sueldoBruto * 0.0304))
	, Borrado bit
	, fechaRegistro smalldatetime default(getdate())
)
Go

CREATE PROCEDURE createEmpleado
@Nombre varchar(25), @Apellido varchar(25), @Cedula varchar(11), @sueldoBruto money
AS
INSERT INTO Empleado(Nombre, Apellido, Cedula, sueldoBruto, Borrado, fechaRegistro) VALUES(@Nombre, @Apellido, @Cedula, @sueldoBruto, 0, GETDATE())
GO

CREATE PROCEDURE findByCedula
@Cedula varchar(11)
AS
SELECT Nombre, Apellido, sueldoBruto, (sueldoBruto * 0.0287) AS AFP, (sueldoBruto * 0.0304) AS ARS, ((sueldoBruto * 0.0287) + (sueldoBruto * 0.0304)) AS totalRetenciones, sueldoNeto FROM Empleado WHERE Borrado=0 AND Cedula = @Cedula
GO

CREATE PROCEDURE updateEmpleado
@Cedula varchar(11), @sueldoBruto MONEY
AS
UPDATE Empleado SET sueldoBruto = @sueldoBruto WHERE Cedula = @Cedula AND Borrado=0
GO

CREATE PROCEDURE softDelete
@Cedula varchar(11)
AS
UPDATE Empleado SET Borrado = 1 WHERE Cedula = @Cedula
GO

select * from Empleado

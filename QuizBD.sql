use Quiz

CREATE PROCEDURE [dbo].[sp_GetAllEmployees]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Empleados e
    ORDER BY e.EmpleadoId DESC;
END

--Add
CREATE PROCEDURE sp_AddEmployee 
    @Nombre varchar(50),
    @Salario float
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Empleados (Nombre, Salario) VALUES 
    (@Nombre, @Salario)
END
GO

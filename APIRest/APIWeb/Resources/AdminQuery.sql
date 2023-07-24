--INGRESO DE ROL Y USUARIO ADMIN POR BASE DE DATOS

INSERT INTO Users
( [Name], Email, Password, UserRol)
VALUES
('Celia', 'garciacastillacelia@gmail.com', '123abc', 1)

SELECT * FROM Users

INSERT INTO Roltype
([RolName])
VALUES
('Administrador')

SELECT * FROM Roltype


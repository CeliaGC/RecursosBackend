select * from UserRols
select * from Users
select * from Authorizations
select * from Rols_Authorizations

INSERT INTO UserRols
([Name])
VALUES
('Administrador'),
('Operario')

INSERT INTO Users
(IdRol, UserName, InsertDate, UpdateDate, IsActive, EncryptedPassword, EncryptedToken, TokenExpireDate, FailedConsecutiveLogins)
VALUES
(1, 'chotsourian.marcos@gmail.com', GETDATE(), GETDATE(), 1, '$2a$11$V6c1zrNzHljeiIQ81bLaoeogagZWvr2JUkUs8CHmWzHYJ6T2l0S5q', '', GETDATE(), 0)
--la pass es asdasd2

INSERT INTO Authorizations
(ControllerName, ActionName, HTTPMethodType, InsertDate, [Name])
VALUES
('user', 'insertuser', 'POST', GETDATE(), 'InsertUser')

INSERT INTO Rols_Authorizations
(IdRol, IdAuthorization, IsActive)
VALUES
(1, 1, 1)
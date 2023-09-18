select * from t_user_rols
select * from t_users

INSERT INTO t_user_rols
(Id, [Name], IsActive)
VALUES
(1, 'Administrador', 1),
(2, 'Operario', 1)

INSERT INTO t_users
(IdRol, UserName, InsertDate, UpdateDate, IsActive, EncryptedPassword, EncryptedToken, TokenExpireDate)
VALUES
(1, 'example.user@gmail.com', GETDATE(), GETDATE(), 1, '$2a$11$V6c1zrNzHljeiIQ81bLaoeogagZWvr2JUkUs8CHmWzHYJ6T2l0S5q', '', GETDATE())
--la pass es asdasd2
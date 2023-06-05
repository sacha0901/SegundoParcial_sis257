-- DDL
CREATE DATABASE Parcial2Amc;
USE [master]
GO
CREATE LOGIN [usrparcial2] WITH PASSWORD=N'12345678', 
   DEFAULT_DATABASE=[Parcial2Amc], 
   CHECK_EXPIRATION=OFF, 
   CHECK_POLICY=ON
GO
USE [Parcial2Amc]
GO
CREATE USER [usrparcial2] FOR LOGIN [usrparcial2]
GO
USE [Parcial2Amc]
GO
ALTER ROLE [db_owner] ADD MEMBER [usrparcial2]
GO

DROP TABLE Serie;

CREATE TABLE Serie(
	id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	titulo VARCHAR(250) NOT NULL,
	sinopsis VARCHAR(5000) NOT NULL,
	director VARCHAR(100) NOT NULL,
	duracion INT,
	fechaEstreno DATETIME NOT NULL, 
	registroActivo BIT NULL DEFAULT 1
);


ALTER TABLE Serie ADD usuarioRegistro VARCHAR(100) NULL DEFAULT SUSER_SNAME();
ALTER TABLE Serie ADD fechaRegistro DATETIME NULL DEFAULT GETDATE();


CREATE PROC paSerieListar @parametro VARCHAR(50)
AS
  SELECT id, titulo, sinopsis , director, duracion, fechaEstreno,
		 usuarioRegistro, fechaRegistro
  FROM Serie
  WHERE registroActivo=1 AND 
		titulo+sinopsis+director LIKE '%'+REPLACE(@parametro,' ','%')+'%'

EXEC paSerieListar 'La casa'

INSERT INTO Serie (titulo,sinopsis,director,duracion,fechaEstreno)
VALUES ('La casa de papel', 'Es un serie excelente', 'Anonimo',2,20-05-2020);
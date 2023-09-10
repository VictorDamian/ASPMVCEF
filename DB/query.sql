CREATE DATABASE PRACTICAMVC
GO
USE PRACTICAMVC

CREATE TABLE USERS
(
IDUSER INT IDENTITY(1,1) PRIMARY KEY,
USERNAME VARCHAR(20)UNIQUE NOT NULL,
PASSWORD VARCHAR(30)NOT NULL,
IDSTATE INT NOT NULL
)
GO

CREATE TABLE USTATE
(
IDSTATE INT PRIMARY KEY,
NAME VARCHAR(20) NOT NULL
)
GO

ALTER TABLE USERS
ADD CONSTRAINT FK_IDSTATE
FOREIGN KEY(IDSTATE)
REFERENCES USTATE(IDSTATE)
GO

INSERT INTO USTATE VALUES
(1,'Activo'),
(2,'Inactivo'),
(3,'Eliminado')
GO

INSERT INTO USERS VALUES
('Dantes','1234',1)
GO

CREATE TABLE EMPLOYEE
(
IDEMP INT IDENTITY(1,1) PRIMARY KEY,
NAME NVARCHAR (80) NOT NULL,
AGE INT NOT NULL,
MAIL NVARCHAR (150)NOT NULL,
POSITION NVARCHAR(100)NOT NULL,
)
GO

INSERT INTO EMPLOYEE VALUES
('Memito',21,'memito32@gmail.con', 'Administrador'),
('Juanito', 31,'juanito@hotmail.com','Contador'),
('Carmensita', 25,'carmen133@outlook.com','Dise�ador')
GO
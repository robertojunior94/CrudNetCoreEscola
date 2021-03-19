CREATE DATABASE Escola
GO

USE Escola
GO



CREATE TABLE Perfil 
(
	Id INT IDENTITY NOT NULL
,	Descricao VARCHAR(50) NOT NULL
,	PRIMARY KEY(Id)
)
GO

INSERT INTO Perfil (Descricao) VALUES ('Escola')
GO
INSERT INTO Perfil (Descricao) VALUES ('Professor')
GO
INSERT INTO Perfil (Descricao) VALUES ('Aluno')
GO

CREATE TABLE Usuario 
(
	Id INT IDENTITY NOT NULL
,	PerfilId INT NOT NULL
,	Nome VARCHAR(100) NOT NULL
,	Email VARCHAR(100) NOT NULL
,	Senha VARCHAR(20) NOT NULL
,	CpfCnpj VARCHAR(20) NULL
,	PRIMARY KEY(Id)
,	FOREIGN KEY (PerfilId) REFERENCES Perfil(Id)
)
GO

INSERT INTO Usuario
(PerfilId, Nome, Email, Senha) VALUES (1,'Usuário Escola','escola@escola.com','senha1')
GO

INSERT INTO Usuario
(PerfilId, Nome, Email, Senha) VALUES (2,'Usuário Professor','professor@professor.com','senha1')
GO

INSERT INTO Usuario
(PerfilId, Nome, Email, Senha) VALUES (3,'Usuário Aluno','aluno@aluno.com','senha1')
GO

CREATE TABLE Escola 
(
	Id INT IDENTITY NOT NULL
,	Nome VARCHAR(100) NOT NULL
,	PRIMARY KEY(Id)
)
GO

INSERT INTO Escola (Nome) VALUES('Unip') 
GO
INSERT INTO Escola (Nome) VALUES('Anhanguera') 
GO
INSERT INTO Escola (Nome) VALUES('FMU') 
GO
INSERT INTO Escola (Nome) VALUES('UMC') 
GO

CREATE TABLE Turma
(
	Id INT IDENTITY NOT NULL
,	EscolaId INT NOT NULL
,	Nome VARCHAR(100) NOT NULL
,	PRIMARY KEY(Id)
,	FOREIGN KEY (EscolaId) REFERENCES Escola(Id)
)

INSERT INTO Turma (EscolaId, Nome) VALUES (1,'Tecnlogia da Informação') 
GO
INSERT INTO Turma (EscolaId, Nome) VALUES (1,'Ciências Contábeis') 
GO
INSERT INTO Turma (EscolaId, Nome) VALUES (2,'Odonto') 
GO
INSERT INTO Turma (EscolaId, Nome) VALUES (2,'Física') 
GO
INSERT INTO Turma (EscolaId, Nome) VALUES (3,'Biologia') 
GO
INSERT INTO Turma (EscolaId, Nome) VALUES (3,'Pedagogia') 
GO
INSERT INTO Turma (EscolaId, Nome) VALUES (4,'Medicina VET') 
GO

CREATE TABLE Aluno
(
	Id INT IDENTITY NOT NULL
,	TurmaId INT NOT NULL
,	Nome VARCHAR(100) NOT NULL
,	Nota DECIMAL(10,2) 
,	PRIMARY KEY(Id)
,	FOREIGN KEY (TurmaId) REFERENCES Turma(Id)
)

INSERT INTO Aluno (TurmaId, Nome, Nota) VALUES (1,'João Medeiros', 8) 
GO
INSERT INTO Aluno (TurmaId, Nome, Nota) VALUES (1,'Alice Braga', 6) 
GO
INSERT INTO Aluno (TurmaId, Nome, Nota) VALUES (1,'Melissa Vaz', 10) 
GO
INSERT INTO Aluno (TurmaId, Nome, Nota) VALUES (1,'Lucas Santana', 5) 
GO
INSERT INTO Aluno (TurmaId, Nome, Nota) VALUES (1,'Cida Torres', 8.5) 
GO
INSERT INTO Aluno (TurmaId, Nome, Nota) VALUES (1,'João Medeiros', 8) 
GO
INSERT INTO Aluno (TurmaId, Nome, Nota) VALUES (2,'Tony Luz', 8) 
GO
INSERT INTO Aluno (TurmaId, Nome, Nota) VALUES (2,'Sabrina Reis', 10) 
GO
INSERT INTO Aluno (TurmaId, Nome, Nota) VALUES (3,'Rodolfo Silva', 2) 
GO
INSERT INTO Aluno (TurmaId, Nome, Nota) VALUES (3,'Irene Medeiros', 8) 
GO
INSERT INTO Aluno (TurmaId, Nome, Nota) VALUES (4,'Santiago Liz', 8) 
GO



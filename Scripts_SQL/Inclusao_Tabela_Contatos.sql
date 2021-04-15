/****** Script do comando SelectTopNRows de SSMS  ******/
USE ArquiteturaLimpa

INSERT INTO Contatos (Nome, Telefone, Email, CPF) SELECT 'Paulo Fonseca', '987871010', 'paulo@hotmail.com', '122.305.555-10'
INSERT INTO Contatos (Nome, Telefone, Email, CPF) SELECT 'Aline Machado', '987871011', 'aline@hotmail.com', '122.305.555-11'
INSERT INTO Contatos (Nome, Telefone, Email, CPF) SELECT 'Rafael Botelho', '987871012', 'rafael@hotmail.com', '122.305.555-12'
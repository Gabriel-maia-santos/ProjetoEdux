USE EduX;
SELECT * FROM Usuario
SELECT * FROM Perfil
SELECT * FROM Categoria
SELECT * FROM Curso
SELECT * FROM Instituicao
SELECT * FROM Turma
SELECT * FROM Dica
SELECT * FROM Objetivo
SELECT * FROM ProfessorTurma
SELECT * FROM Curtida
SELECT * FROM AlunoTurma
SELECT * FROM ObjetivoAluno

INSERT INTO Perfil (IdPerfil,Permissao)
	VALUES
	(NEWID(),'Professor'),
	(NEWID(),'Aluno');

INSERT INTO Categoria (	IdCategoria,Tipo)
	VALUES
	(NEWID(),'Critico'),
	(NEWID(),'Desejavel'),
	(NEWID(),'Oculto');

INSERT INTO Usuario(IdUsuario,Nome,Senha,Email,DataCadastro,DataUltimoAcesso, IdPerfil)
	VALUES
	(NEWID(),'Kaua', '1234578','kaua@gmail.com','2020-03-03T15:00:00','2020-03-03T15:00:00','09799970-39A8-4684-B43C-B398188EB89C');

INSERT INTO Dica(IdDica,Texto,Imagem, IdUsuario)
	VALUES
	(NEWID(),'Como resolver matrizes', 'http:hhwbuyhfbwtvfdwy/imagens','B3B7A676-3708-4917-8FAF-A7424B8A69A6');

INSERT INTO Instituicao(IdInstituicao,Nome,Logradouro,Numero,Complemento,Bairro,Cidade, UF, CEP)
	VALUES
	(NEWID(),'SENAI INFORMATICA', 'Alameda Barão de limeira','289','Prédio','Santa Cecilia','São Paulo', 'SP','01202-001');

INSERT INTO Objetivo(IdObjetivo,Descricao, IdCategoria)
	VALUES
	(NEWID(),'fazer licão do geekie', '617B2313-3573-4C5D-B322-919AF6549529'),
	(NEWID(),'Fazer mapa mental sobre duplicidade do DNA','DA1F32AE-853B-4D57-8F4C-B4D025C119F4'),
	(NEWID(),'Entregar Redação sobre socialismo e comunismo','5253315D-EF23-4BA7-BA99-FD19B345FDB2');

INSERT INTO Curso (IdCurso,Titulo, IdInstituicao)
	VALUES
	(NEWID(),'DEV','382BE7E5-3A3D-4EE0-B9C6-4BDFF86341FB'),
	(NEWID(),'Analises Quimica','382BE7E5-3A3D-4EE0-B9C6-4BDFF86341FB'),
	(NEWID(),'Multimidia','382BE7E5-3A3D-4EE0-B9C6-4BDFF86341FB');

INSERT INTO Turma(IdTurma,Descricao, IdCurso)
	VALUES
	(NEWID(),'Sala extremamente peculiar', '430D9C4E-1AB2-4F83-98FD-EAFAE7DBB336');


INSERT INTO Curtida(IdCurtida,IdUsuario,IdDica)
	VALUES
	(NEWID(),'B3B7A676-3708-4917-8FAF-A7424B8A69A6','E45C4FB5-EBA0-46C1-B854-20581F85E533' );

INSERT INTO ProfessorTurma(IdProfessorTurma,Descricao,IdUsuario,IdTurma)
	VALUES
	(NEWID(),'Professor Ricardo: DEV', '8327CBFB-F2A5-4102-9A8D-5640DBB585B5','0C2E0BB8-E03E-488C-97C4-419B48F6E9D2');

INSERT INTO AlunoTurma(IdAlunoTurma,Matricula,IdUsuario,IdTurma)
	VALUES
	(NEWID(),'89585875','B3B7A676-3708-4917-8FAF-A7424B8A69A6','77DB0703-5102-4F98-A03D-76408F819C1E');

INSERT INTO ObjetivoAluno(IdObjetivoAluno,DataAlcancado,Nota,IdAlunoTurma,IdObjetivo)
	VALUES
	(NEWID(),'2020-03-03T15:00:00',9.5,'EB85981E-7EAE-490D-91F1-96BD1A52DF58','F1DD2C9C-D278-4367-876D-045C0C181C99');

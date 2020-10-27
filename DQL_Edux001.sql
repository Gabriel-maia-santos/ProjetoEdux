
	SELECT AlunoTurma.Matricula, Turma.Descricao , Usuario.Nome FROM AlunoTurma
			INNER JOIN Turma ON AlunoTurma.IdTurma = Turma.IdTurma
			INNER JOIN Usuario ON Usuario.IdUsuario = AlunoTurma.IdUsuario
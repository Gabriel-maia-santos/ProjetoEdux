using Projeto_EduXSprint2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EduXSprint2.Interfaces
{
    interface IProfessorTurmaRepository
    {
        // Interface assina meu contrato
        // CRUD
        List<ProfessorTurma> LerTodos();
        ProfessorTurma BuscarPorId(Guid id);
        void Cadastrar(ProfessorTurma professorturma);

        void Alterar(Guid id, ProfessorTurma professorturma);

        void Excluir(Guid id);
    }
}

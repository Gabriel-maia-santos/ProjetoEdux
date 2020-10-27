using Projeto_EduXSprint2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EduXSprint2.Interfaces
{
    interface ICursoRepository
    {
        // Interface assina meu contrato
        // CRUD
        List<Curso> LerTodos();
        Curso BuscarPorId(Guid id);

        List<Curso> BuscarporTitulo(string titulo);

        void Cadastrar(Curso curso);

        void Alterar(Guid id, Curso curso);

        void Excluir(Guid id);
    }
}

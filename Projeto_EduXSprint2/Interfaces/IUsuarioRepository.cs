using Projeto_EduXSprint2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EduXSprint2.Interfaces
{
    interface IUsuarioRepository
    {
        // Interface assina meu contrato
        // CRUD
        List<Usuario> LerTodos();

        Usuario BuscarPorId(Guid id);

        List<Usuario> BuscarporNome(string nome);

        void Cadastrar(Usuario usuario);

        void Alterar(Guid id, Usuario usuario);

        void Excluir(Guid id);
    }
}

using Projeto_EduXSprint2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EduXSprint2.Interfaces
{
    interface IDicaRepository
    {
        List<Dica> LerTodos();
        Dica BuscarPorId(Guid id);
        void Adicionar(Dica dica);
        void Editar(Dica dica);
        void Excluir(Guid id);
    }
}

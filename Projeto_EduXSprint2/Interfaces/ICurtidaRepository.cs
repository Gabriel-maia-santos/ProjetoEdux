using Projeto_EduXSprint2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EduXSprint2.Interfaces
{
    interface ICurtidaRepository
    {
        List<Curtida> LerTodos();
        Curtida BuscarPorId(Guid id);
        void Adicionar(Curtida curtida);
        void Editar(Curtida curtida);
        void Remover(Guid id);
    }
}

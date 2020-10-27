using Projeto_EduXSprint2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EduXSprint2.Interfaces
{
    interface ICategoria
    {
        List<Categoria> LerTodos();

        Categoria BuscarPorId(Guid id);

        List<Categoria> BuscarPorTipo(string tipo);

        void Adicionar(Categoria categoria);

        void Alterar(Guid id, Categoria categoria);

        void Deletar(Guid id);
    }
}

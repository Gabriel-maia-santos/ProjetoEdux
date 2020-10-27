using Projeto_EduXSprint2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EduXSprint2.Interfaces
{
    interface IPerfil
    {
        List<Perfil> LerTodos();

        Perfil BuscarPorId(Guid id);

        List<Perfil> BuscarPorPermissao(string permissao);

        void Adicionar(Perfil perfil);

        void Alterar(Guid id, Perfil perfil);

        void Deletar(Guid id);
    }
}

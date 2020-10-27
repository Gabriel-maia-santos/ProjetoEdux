using Projeto_EduXSprint2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EduXSprint2.Interfaces
{
    interface IInstituicao
    {
        List<Instituicao> LerTodos();

        Instituicao BuscarPorId(Guid id);

        List<Instituicao> BuscarPorDados(string Nome, string Logradouro, string Numero, string Complemento, string Bairro, string Cidade, string Uf, string Cep);
        void Adicionar(Instituicao instituicao);

        void Alterar(Guid id, Instituicao instituicao);

        void Deletar(Guid id);
    }
}

using Projeto_EduXSprint2.Contexts;
using Projeto_EduXSprint2.Domains;
using Projeto_EduXSprint2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EduXSprint2.Repositories
{
    public class InstituicaoRepository : IInstituicao
    {

        private readonly EduXContext _ctx;

        public InstituicaoRepository()
        {
            _ctx = new EduXContext();
        }
        public void Adicionar(Instituicao instituicao)
        {
            try
            {
                //Adiciona uma instituição
                _ctx.Instituicao.Add(instituicao);
                //Salva as alterações
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Instituicao> BuscarPorDados(string Nome, string Logradouro, string Numero, string Complemento, string Bairro, string Cidade, string Uf, string Cep)
        {
            //Retorna todas as informações buscadas
            return _ctx.Instituicao.Where(i => i.Nome.Contains(Nome) || i.Logradouro.Contains(Logradouro) || i.Numero.Contains(Numero) || i.Complemento.Contains (Complemento) || i.Bairro.Contains(Bairro) || i.Cidade.Contains(Cidade) || i.Uf.Contains(Uf) || i.Cep.Contains(Cep)).ToList();

        }

        public Instituicao BuscarPorId(Guid id)
        {
            try
            {
                //Faz a busca através do Id
                Instituicao instituicao = _ctx.Instituicao.FirstOrDefault(i => i.IdInstituicao == id);
                //Retorna a instituição encontrada
                return instituicao;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        public void Alterar(Guid id, Instituicao instituicao)
        {
            try
            {
                //Faz a busca dos Ids
                Instituicao instituicao1 = BuscarPorId(id);
                //Se o prefil não for encontrado ele irá aparecer está mensagem de erro
                if (instituicao1 == null)
                    throw new Exception("A instituição não foi encontrada");

                //Se existir a instituicao, ele irá alteralo através dos dados
                instituicao1.Nome = instituicao.Nome;
                instituicao1.Logradouro = instituicao.Logradouro;
                instituicao1.Numero = instituicao.Numero;
                instituicao1.Complemento = instituicao.Complemento;
                instituicao1.Bairro = instituicao.Bairro;
                instituicao1.Cidade = instituicao.Cidade;
                instituicao1.Uf = instituicao.Uf;
                instituicao1.Cep = instituicao.Cep;

                _ctx.Instituicao.Update(instituicao1);
                //Salva as alterações
                _ctx.SaveChanges();


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Instituicao> LerTodos()
        {
            try
            {
                //Lista todas as instituições
                return _ctx.Instituicao.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                //Faz a busca dos Ids
                Instituicao instituicao1 = BuscarPorId(id);
                //Se a instiuição não for encontrado ele irá aparecer está mensagem de erro
                if (instituicao1 == null)
                    throw new Exception("A instituição não foi encontrada");
                //Deleta as instituições
                _ctx.Instituicao.Remove(instituicao1);
                //Salva as alterações
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

using Projeto_EduXSprint2.Contexts;
using Projeto_EduXSprint2.Domains;
using Projeto_EduXSprint2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EduXSprint2.Repositories
{
    public class PerfilRepository : IPerfil
    {
        private readonly EduXContext _ctx;

        public PerfilRepository()
        {
            _ctx = new EduXContext();
        }

        /// <summary>
        /// Adiciona o Perfil
        /// </summary>
        /// <param name="perfil"></param>
        public void Adicionar(Perfil perfil)
        {
            try
            {
                //Adiciona o Perfil
                _ctx.Perfil.Add(perfil);

                //Salva as alterações
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Faz a busca dos perfis através dos Ids
        /// </summary>
        /// <param name="id">Id do Perfil</param>
        /// <returns></returns>
        public Perfil BuscarPorId(Guid id)
        {
            try
            {
                //Faz a busca através do Id
                Perfil perfil = _ctx.Perfil.FirstOrDefault(p => p.IdPerfil == id);

                return perfil;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



        /// <summary>
        /// Busca o Perfil através da permissão que ele possui
        /// </summary>
        /// <param name="permissao">Permissão do Perfil</param>
        /// <returns></returns>
        public List<Perfil> BuscarPorPermissao(string permissao)
        {
            try
            {
                //Faz a busca através de sua Permissão
                return _ctx.Perfil.Where(p => p.Permissao.Contains(permissao)).ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita o Perfl através de seu Id
        /// </summary>
        /// <param name="perfil">Id do Perfil</param>
        /// /// <param name="id">Id do Perfil</param>

        public void Alterar(Guid id, Perfil perfil)
        {
            try
            {
                //Faz a busca dos Ids
                Perfil perfils = BuscarPorId(id);
                //Se o prefil não for encontrado ele irá aparecer está mensagem de erro
                if (perfils == null)
                    throw new Exception("O perfil não foi encontrado");

                //Se existir o perfil, ele irá alteralo através de sua permissão
                
                perfils.Permissao = perfil.Permissao;

                _ctx.Perfil.Update(perfils);
                _ctx.SaveChanges();


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista os Perfis
        /// </summary>
        /// <returns>Perfil</returns>
        public List<Perfil> LerTodos()
        {
            try
            {
                //Lista todos os Perfis
                return _ctx.Perfil.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove os Perfils
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(Guid id)
        {
            try
            {
                //Faz a busca dos Ids
                Perfil perfils = BuscarPorId(id);
                //Se o prefil não for encontrado ele irá aparecer está mensagem de erro
                if (perfils == null)
                    throw new Exception("O perfil não foi encontrado");
                //Se o perfil existir, ele irá remove-lô
                _ctx.Perfil.Remove(perfils);
                //Deleta os Perfils
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}

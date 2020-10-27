using Projeto_EduXSprint2.Contexts;
using Projeto_EduXSprint2.Domains;
using Projeto_EduXSprint2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EduXSprint2.Repositories
{
    public class CurtidaRepository : ICurtidaRepository
    {
        private readonly EduXContext contextinho;
        public CurtidaRepository()
        {
            contextinho = new EduXContext();
        }
        /// <summary>
        /// Adiciona uma curtida
        /// </summary>
        /// <param name="curtida"> Id da Curtida</param>
        public void Adicionar(Curtida curtida)
        {
            try
            {
                contextinho.Curtida.Add(curtida);
                contextinho.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Busca pelo Id da Curtida
        /// </summary>
        /// <param name="id"> Id da Curtida</param>
        /// <returns> Retorna um Id da Curtida </returns>
        public Curtida BuscarPorId(Guid id)
        {
            try
            {
                return contextinho.Curtida.Find(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Edita uma Curtida
        /// </summary>
        /// <param name="curtida"> Id da Curtida</param>
        public void Editar(Curtida curtida)
        {
            try
            {
                Curtida curtidatemp = BuscarPorId(curtida.IdCurtida);

                if (curtidatemp == null)
                    throw new Exception("Dica não encontrada.");

                curtidatemp.IdUsuario = curtida.IdUsuario;
                curtidatemp.IdDica = curtida.IdDica;

                contextinho.Update(curtidatemp);
                contextinho.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Lê todas as Curtidas
        /// </summary>
        /// <returns> Retorna todas Curtidas cadastradas </returns>
        public List<Curtida> LerTodos()
        {
            try
            {
                return contextinho.Curtida.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Remova uma Curtida
        /// </summary>
        /// <param name="id"> Id da Curtida</param>
        public void Remover(Guid id)
        {
            try
            {
                Curtida curtidatemp = BuscarPorId(id);

                if (curtidatemp == null)
                    throw new Exception("Dica não encontrada");

                contextinho.Curtida.Remove(curtidatemp);
                contextinho.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

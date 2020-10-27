using Projeto_EduXSprint2.Contexts;
using Projeto_EduXSprint2.Domains;
using Projeto_EduXSprint2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EduXSprint2.Repositories
{
    public class ObjetivoRepository : IObjetivoRepository
    {
        private readonly EduXContext context;
        public ObjetivoRepository()
        {

            //Instanciamos o contexto para que seja possível trabalhar suas propriedades
            context = new EduXContext();
        }

        #region Leitura
        public List<Objetivo> Listar()
        {
            try
            {
                // Lista todos objetivos cadastrados
                return context.Objetivo.ToList();
            }
            catch (Exception ex)
            {
                //Retorna mensagem de erro
                throw new Exception(ex.Message);
            }
        }

        public Objetivo Buscar(Guid id)
        {
            try
            {
                // Busca um objetivo cadastrado no banco de dados, passando como parâmetro seu id 
                return context.Objetivo.Find(id);
            }
            catch (Exception ex)
            {
                //Retorna mensagem de erro
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Gravação
        public void AdicionarObjetivo(Objetivo obj)
        {
            try
            {
                //Adiciona o novo item Objetivo ao contexto
                context.Objetivo.Add(obj);
                //Salva as alterações realizadas
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Retorna mensagem de erro
                throw new Exception(ex.Message);
            }
        }
        public void Editar(Guid id , Objetivo obj)
        {
            try
            {
                //Verifica se o item que estamos tentando editar tem algum id existente no banco de dados
                Objetivo newObjetivo = Buscar(id);
                if (newObjetivo == null)
                {
                    //Caso o item não exista, retorna mensagem de erro
                    throw new Exception("O objetivo procurado não corresponde a nenhum dos objetivos cadastrados");
                }
                //Caso exista, atualiza suas propriedas com as novas desejadas
                newObjetivo.Descricao = obj.Descricao;
                newObjetivo.IdCategoria = obj.IdCategoria;
                //Salva as alterações no contexto
                context.Objetivo.Update(newObjetivo);
                context.SaveChanges();


            }
            catch (Exception ex)
            {
                //Retorna mensagem de erro
                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid id)
        {
            try
            {
                //Verifica se o item que estamos tentando remover tem algum id existente no banco de dados
                Objetivo newObjetivo = Buscar(id);
                if (newObjetivo == null)
                {
                    //Caso o item não exista, retorna mensagem de erro
                    throw new Exception("O objetivo procurado não corresponde a nenhum dos objetivos cadastrados");
                }
                //Caso exista, remove o objeto da tabela ObjetivoAluno
                context.Objetivo.Remove(newObjetivo);
                //Salva as alterações realizadas no contexto
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Retorna mensagem de erro
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}

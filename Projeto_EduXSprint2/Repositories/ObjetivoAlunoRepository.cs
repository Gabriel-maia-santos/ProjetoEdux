using Projeto_EduXSprint2.Contexts;
using Projeto_EduXSprint2.Domains;
using Projeto_EduXSprint2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace Projeto_EduXSprint2.Repositories
{
    public class ObjetivoAlunoRepository : IObjetivoAlunoRepository
    {
        private readonly EduXContext context;
        public ObjetivoAlunoRepository()
        {
            //Instanciamos o contexto para que seja possível trabalhar suas propriedades
            context = new EduXContext();
        }

        #region Leitura
        public List<ObjetivoAluno> Listar()
        {
            try
            {
                // Lista todos objetivos cadastrados
                return context.ObjetivoAluno.ToList();
            }
            catch (Exception ex)
            {
                //Retorna mensagem de erro
                throw new Exception(ex.Message);
            }
        }

        public ObjetivoAluno Buscar(Guid id)
        {
            try
            {
                // Busca um objetivo cadastrado no banco de dados, passando como parâmetro seu id 
                return context.ObjetivoAluno.Find(id);
            }
            catch (Exception ex)
            {
                //Retorna mensagem de erro
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Gravação

        public void Adicionar(ObjetivoAluno objAluno)
        {
            try
            {
                /* Uma das regras de negócio definidas, fora a de que o atributo "Nota" adicionado deveria estar compreendido
                 * entre 0 e 100. As condicionais if e else if, tem o papel de estabelecer essa regra, retornando uma mensagem
                 de erro caso o usuário tente passar um valor fora do estabelecido */
                  
                if(objAluno.Nota > 100)
                {
                    throw new Exception("O valor inserido para nota é invalido, por favor insira alguma nota entre 0 e 100");
                }
                else if (objAluno.Nota < 0)
                {
                    throw new Exception("O valor inserido para nota é invalido, por favor insira alguma nota entre 0 e 100");
                }
                //Adiciona o novo item ObjetivoAluno ao contexto
                context.ObjetivoAluno.Add(objAluno);
                //Salva as alterações realizadas
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
                ObjetivoAluno objetivoAl = Buscar(id);
                if (objetivoAl == null)
                {
                    //Caso o item não exista, retorna mensagem de erro
                    throw new Exception("ID não encontrado");
                }

                //Caso exista, remove o objeto da tabela ObjetivoAluno
                context.ObjetivoAluno.Remove(objetivoAl);
                //Salva as alterações realizadas no contexto
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Retorna mensagem de erro
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Guid id, ObjetivoAluno objAluno)
        {
            try
            {
                //Verifica se o item que estamos tentando editar tem algum id existente no banco de dados
                ObjetivoAluno objetivoAl = Buscar(id);
                if(objetivoAl == null)
                {
                    //Caso o item não exista, retorna mensagem de erro
                    throw new Exception("ID não encontrado");
                }
                else
                {
                    //Caso exista, atualiza suas propriedas com as novas desejadas
                    objetivoAl.Nota = objAluno.Nota;
                    objetivoAl.IdAlunoTurma = objAluno.IdAlunoTurma;
                    objetivoAl.IdObjetivo = objAluno.IdObjetivo;
                    if (objAluno.Nota > 100)
                    {
                        throw new Exception("O valor inserido para nota é invalido, por favor insira alguma nota entre 0 e 100");
                    }
                    else if (objAluno.Nota < 0)
                    {
                        throw new Exception("O valor inserido para nota é invalido, por favor insira alguma nota entre 0 e 100");
                    }
                    context.ObjetivoAluno.Update(objetivoAl);
                    //Salva as alterações no contexto
                    context.SaveChanges();
                }
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

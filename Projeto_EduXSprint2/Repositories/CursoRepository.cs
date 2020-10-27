using Projeto_EduXSprint2.Contexts;
using Projeto_EduXSprint2.Domains;
using Projeto_EduXSprint2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EduXSprint2.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        // readonly significa somente leitura, sem alterações
        // uso do encapsulamento
        private readonly EduXContext _context;

        public CursoRepository()
        {
            _context = new EduXContext();
        }
        // ctor é um atalho para criar um metodo construtor
        // Region é um comando de organização dos codigos

        #region Leitura
        /// <summary>
        /// Lista todos os Cursos cadastrados
        /// </summary>
        /// <returns>Lista dos cursos cadastrados</returns>
        public List<Curso> LerTodos()
        {
            // Try catch é uma tratativa de erros
            try
            {
                // Aqui chamamos o metodo de listagem
                return _context.Curso.ToList();
            }
            // Caso de erro retorna uma excessao
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Aqui buscamos um Curso pelo seu Id
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns>retorna o produto buscado</returns>
        public Curso BuscarPorId(Guid id)
        {
            // Try catch é uma tratativa de erros
            try
            {   // Chamamos o metodo que busca pelo id
                return _context.Curso.Find(id);
            }
            // Caso de erro retorna uma excessao
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Aqui buscamos um Curso pelo seu Titulo
        /// </summary>
        /// <param name="titulo">titulo do curso</param>
        /// <returns>Retorna o cuso encontrado</returns>
        public List<Curso> BuscarporTitulo(string titulo)
        {
            // Try catch é uma tratativa de erros
            try
            {
                // Contains == WHERE
                // Aqui fazemos uma expressao lambda para buscar por titulo
                return _context.Curso.Where(c => c.Titulo.Contains(titulo)).ToList();
            }
            // Caso de erro retorna uma excessao
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Gravacao
        /// <summary>
        /// Aqui cadastramos o curso
        /// </summary>
        /// <param name="curso">Objeto do tipo Curso</param>
        public void Cadastrar(Curso curso)
        {
            // try - tente
            // catch - excessão
            // Try catch é um tipo de tratativa para o nosso erro
            try
            {
                // Adiciona objeto do tipo curso ao dbset do contexto
                _context.Add(curso);
                //_ctx.Set<Curso>().Add(curso);
                //_ctx.Entry(curso).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                //Salva as alterações no contexto
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Aqui excluimos um Curso
        /// </summary>
        /// <param name="id">Id do Curso</param>
        public void Excluir(Guid id)
        {
            try
            {
                // Curso cursoTemp = cont.Curso.Find(produto.Id);
                // Buscar curso pelo ID
                Curso cursoTemp = BuscarPorId(id);

                // verifica se o curso existe
                // Caso não gera um ex
                if (cursoTemp == null)
                    throw new Exception("Produto não encontrado");

                // Remove os cursos do dbset
                _context.Curso.Remove(cursoTemp);
                // salva as alterações do contexto
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Altera um curso
        /// </summary>
        /// <param name="id"></param>
        /// <param name="curso"></param>
        public void Alterar(Guid id,Curso curso)
        {
            try
            {
                Curso cursoTemp = BuscarPorId(id);

                if (cursoTemp == null)
                    throw new Exception("Curso não encontrada");


                cursoTemp.IdCurso       =  curso.IdCurso;
                cursoTemp.IdInstituicao =  curso.IdInstituicao;
                cursoTemp.Titulo        =  curso.Titulo;


                _context.Curso.Update(cursoTemp);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}

using Projeto_EduXSprint2.Contexts;
using Projeto_EduXSprint2.Domains;
using Projeto_EduXSprint2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EduXSprint2.Repositories
{
    public class ProfessorTurmaRepository : IProfessorTurmaRepository
    {
        private readonly EduXContext cont;
        public ProfessorTurmaRepository()
        {
            cont = new EduXContext();
        }
        #region Gravacao
        /// <summary>
        /// Cadastra um professor
        /// </summary>
        /// <param name="professorturma">Objeto do tipo professor</param>
        public void Cadastrar(ProfessorTurma professorturma)
        {
            try
            {
                // Adiciona o professor
                cont.ProfessorTurma.Add(professorturma);

                // Salva as alterações no DbContext
                cont.SaveChanges();
            }
            // Caso n seja possiveç cadastrar gera uma excessao
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
       /// <summary>
       /// Altera um professor
       /// </summary>
       /// <param name="id">id do prefossor</param>
       /// <param name="professorturma">Objeto do tipo professor</param>
        public void Alterar(Guid id, ProfessorTurma professorturma)
        {
            try
            {
                ProfessorTurma professorTemp = BuscarPorId(id);

                if (professorTemp == null)
                    throw new Exception("Professor não encontrada");


                professorTemp.IdProfessorTurma  = professorturma.IdProfessorTurma;
                professorTemp.IdUsuario = professorturma.IdUsuario;
                professorTemp.Descricao = professorturma.Descricao;



                cont.ProfessorTurma.Update(professorTemp);
                cont.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Exclui uma Turma
        /// </summary>
        /// <param name="id">Id do Professor Turma</param>
        public void Excluir(Guid id)
        {
            ProfessorTurma professorTemp = BuscarPorId(id);

            if (professorTemp == null)
            {
                throw new Exception("Essa Turma não foi encontrada");

            }

            // Chama o metodo para remover
            cont.ProfessorTurma.Remove(professorTemp);
            // Salva as alterações feita no DbContext
            cont.SaveChanges();

        }
        #endregion
        #region Leitura
        /// <summary>
        ///  Busca um professor pela sua id
        /// </summary>
        /// <param name="id">Id do professor</param>
        /// <returns>Retorna o professor buscado</returns>
        public ProfessorTurma BuscarPorId(Guid id)
        {
            try
            {
                // Faz a busca pelo id
                return cont.ProfessorTurma.Find(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Lista os professores cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de professor</returns>
        public List<ProfessorTurma> LerTodos()
        {
            try
            {
                // Chama o metodo de lista
                return cont.ProfessorTurma.ToList();
            }
            // Caso aconteça algum imprevisto gera uma excessao
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}

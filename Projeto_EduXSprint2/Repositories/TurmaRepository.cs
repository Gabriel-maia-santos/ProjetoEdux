using Projeto_EduXSprint2.Contexts;
using Projeto_EduXSprint2.Domains;
using Projeto_EduXSprint2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_EduXSprint2.Repositories {
    public class TurmaRepository : ITurma {

        private readonly EduXContext _context;
        public TurmaRepository() {
            _context = new EduXContext();
        }


        /// <summary>
        /// Criando metodo para adicionar dados no banco
        /// </summary>
        /// <param name="turma"></param>
        public void Adicionar(Turma turma) {
            try {
                _context.Turma.Add(turma);

                _context.SaveChanges();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Criando metodo para procurar um id especifico no banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Turma BuscarPorId(Guid id) {
            try {
                return _context.Turma.Find(id);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Criando método para Editar dados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="turma"></param>
        public void Editar(Guid id , Turma turma) {
            try {
                Turma turmaTemp = BuscarPorId(id);

                if (turmaTemp == null)
                    throw new Exception("Turma não encontrada");


                turmaTemp.IdTurma = turma.IdTurma;
                turmaTemp.Descricao = turma.Descricao;
                turmaTemp.IdCurso = turma.IdCurso;

                _context.Turma.Update(turmaTemp);
                _context.SaveChanges();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista de dados
        /// </summary>
        /// <returns></returns>
        public List<Turma> Listar() {
            try {
                return _context.Turma.ToList();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Removendo algo do banco de dados
        /// </summary>
        /// <param name="id"></param>
        public void Remover(Guid id) {
            try {
                Turma turmaTemp = BuscarPorId(id);

                _context.Turma.Remove(turmaTemp);
                _context.SaveChanges();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}

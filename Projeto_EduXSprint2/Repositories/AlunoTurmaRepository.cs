using Projeto_EduXSprint2.Contexts;
using Projeto_EduXSprint2.Domains;
using Projeto_EduXSprint2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_EduXSprint2.Repositories {
    public class AlunoTurmaRepository : IAlunoTurma {
        private readonly EduXContext _context;
        public AlunoTurmaRepository() {
            _context = new EduXContext();
        }

        public void Adicionar(AlunoTurma alunoturma) {
            try {
                _context.AlunoTurma.Add(alunoturma);

                _context.SaveChanges();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public AlunoTurma BuscarPorId(Guid id) {
            try {
                return _context.AlunoTurma.Find(id);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(AlunoTurma alunoturma) {
            try { 
            AlunoTurma alunoturmaTemp = BuscarPorId(alunoturma.IdAlunoTurma);

            if (alunoturmaTemp == null)
                throw new Exception("AlunoTurma não encontrada");

            alunoturmaTemp.Matricula = alunoturma.Matricula;
            alunoturmaTemp.IdAlunoTurma = alunoturma.IdAlunoTurma;

            _context.AlunoTurma.Update(alunoturmaTemp);
            _context.SaveChanges();
        }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        public List<AlunoTurma> Listar() {
            try {
                return _context.AlunoTurma.ToList();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid id) {
            try {
                AlunoTurma alunoturmaTemp = BuscarPorId(id);

                _context.AlunoTurma.Remove(alunoturmaTemp);
                _context.SaveChanges();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}

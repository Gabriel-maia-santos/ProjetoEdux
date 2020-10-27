using Projeto_EduXSprint2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EduXSprint2.Interfaces
{
    interface IObjetivoAlunoRepository
    {
        List<ObjetivoAluno> Listar();
        ObjetivoAluno Buscar(Guid id);
        void Adicionar(ObjetivoAluno objAluno);
        void Remover(Guid id);
        void Editar(Guid id ,ObjetivoAluno objAluno);
     


    }
}

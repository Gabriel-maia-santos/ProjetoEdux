using Projeto_EduXSprint2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EduXSprint2.Interfaces
{
    interface IObjetivoRepository
    {
        List<Objetivo> Listar();
        Objetivo Buscar(Guid id);
        void AdicionarObjetivo(Objetivo obj);
        void Editar(Guid id , Objetivo obj);
        void Remover(Guid id);
    }
}

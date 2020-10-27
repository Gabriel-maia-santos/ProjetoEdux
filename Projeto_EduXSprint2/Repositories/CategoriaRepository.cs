using Projeto_EduXSprint2.Contexts;
using Projeto_EduXSprint2.Domains;
using Projeto_EduXSprint2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EduXSprint2.Repositories
{
    public class CategoriaRepository : ICategoria
    {
        private readonly EduXContext _ctx;

        public CategoriaRepository()
        {
            _ctx = new EduXContext();
        }

        public void Adicionar(Categoria categoria)
        {
            try
            {
                //Adiciona categorias
                _ctx.Categoria.Add(categoria);

                //Salva as Alterações
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Alterar(Guid id,Categoria categoria)
        {
            try
            {
                //Faz a busca dos Ids
                Categoria categoria1 = BuscarPorId(id);
                //Se o prefil não for encontrado ele irá aparecer está mensagem de erro
                if (categoria1 == null)
                    throw new Exception("A sua categoria não foi encontrada");

                //Se existir o perfil, ele irá alteralo através de sua permissão
                categoria1.Tipo = categoria.Tipo;

                _ctx.Categoria.Update(categoria1);
                //Salva as Alterações
                _ctx.SaveChanges();


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Categoria BuscarPorId(Guid id)
        {
            try
            {
                //Faz a busca através do IdCategoria
                Categoria categoria = _ctx.Categoria.FirstOrDefault(c => c.IdCategoria == id);
                //Retorna a categoria encontrada
                return categoria;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Categoria> BuscarPorTipo(string tipo)
        {
            try
            {
                //Faz a busca através de sua Permissão e a retorna
                return _ctx.Categoria.Where(p => p.Tipo.Contains(tipo)).ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Categoria> LerTodos()
        {
            try
            {
                //Lista todas as categorias cadastradas
                return _ctx.Categoria.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                //Faz a busca dos Ids
                Categoria categoria1 = BuscarPorId(id);
                //Se a instiuição não for encontrado ele irá aparecer está mensagem de erro
                if (categoria1 == null)
                    throw new Exception("A instituição não foi encontrada");
                //Remove as categorias
                _ctx.Categoria.Remove(categoria1);
                //Salva as alterações
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

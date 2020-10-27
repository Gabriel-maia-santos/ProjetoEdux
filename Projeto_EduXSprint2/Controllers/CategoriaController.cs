using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto_EduXSprint2.Domains;
using Projeto_EduXSprint2.Interfaces;
using Projeto_EduXSprint2.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projeto_EduXSprint2.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoria _categoriaRepository;

        public CategoriaController()
        {
            _categoriaRepository = new CategoriaRepository();
        }

        /// <summary>
        /// Lista todas as categorias
        /// </summary>
        /// <returns></returns>
        // GET: api/<PerfilController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var categorias = _categoriaRepository.LerTodos();

                if (categorias.Count == 0)
                    return NoContent();

                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        /// <summary>
        /// Faz a busca através dos Ids das categorias
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        // GET api/<PerfilController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Categoria categoria = _categoriaRepository.BuscarPorId(id);

                if (categoria == null)
                    return NotFound();

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Faz a busca através dos Ids das categorias
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        /// 
        // GET api/<PerfilController>/5
        [HttpGet("tipo/{tipo}")]
        public IActionResult Get(string tipo)
        {
            try
            {
                var categoria = _categoriaRepository.BuscarPorTipo(tipo);

                if (categoria == null)
                    return NotFound();

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Cadastra novas categorias
        /// </summary>
        /// <param name="categoria"></param>
        /// 
        /// <returns></returns>
        // POST api/<PerfilController>
        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            try
            {
                _categoriaRepository.Adicionar(categoria);

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Altera as informações das categorias já prontas
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoria"></param>
        /// 
        /// <returns></returns>
        // PUT api/<PerfilController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Categoria categoria)
        {
            try
            {

                _categoriaRepository.Alterar(id, categoria);

                //Retorna Ok com os dados do produto
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Exclui as categorias
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        // DELETE api/<PerfilController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var categoria = _categoriaRepository.BuscarPorId(id);

                if (categoria == null)
                    return NotFound();

                _categoriaRepository.Deletar(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

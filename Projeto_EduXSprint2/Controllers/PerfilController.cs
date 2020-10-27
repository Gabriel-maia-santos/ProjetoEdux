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
    public class PerfilController : ControllerBase
    {

        private readonly IPerfil _perfilRepository;

        public PerfilController()
        {
            _perfilRepository = new PerfilRepository();
        }

        /// <summary>
        /// Cadastra os Perfis
        /// </summary>
        /// <returns></returns>

        // GET: api/<PerfilController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var perfils = _perfilRepository.LerTodos();

                if (perfils.Count == 0)
                    return NoContent();

                return Ok(perfils);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        /// <summary>
        /// Faz a busca através dos Ids dos perfis
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // GET api/<PerfilController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Perfil perfil = _perfilRepository.BuscarPorId(id);

                if (perfil == null)
                    return NotFound();

                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("permissao/{permissao}")]
        public IActionResult Get(string permissao)
        {
            try
            {
                var perfil = _perfilRepository.BuscarPorPermissao(permissao);

                if (perfil == null)
                    return NotFound();

                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Cadastra os Perfils
        /// </summary>
        /// <param name="perfil"></param>
        /// <returns></returns>

        // POST api/<PerfilController>
        [HttpPost]
        public IActionResult Post([FromBody] Perfil perfil)
        {
            try
            {

                _perfilRepository.Adicionar(perfil);

                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Altera as informações dos Perfils
        /// </summary>
        /// <param name="id"></param>
        /// <param name="perfil"></param>
        /// <returns></returns>

        // PUT api/<PerfilController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Perfil perfil)
        {
            try
            {

                _perfilRepository.Alterar(id, perfil);

                //Retorna Ok com os dados do produto
                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclui as informações dos Perfils
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // DELETE api/<PerfilController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var perfil = _perfilRepository.BuscarPorId(id);

                if (perfil == null)
                    return NotFound();

                _perfilRepository.Deletar(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

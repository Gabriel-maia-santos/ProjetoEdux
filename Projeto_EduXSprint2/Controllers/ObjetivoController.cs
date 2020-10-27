using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_EduXSprint2.Domains;
using Projeto_EduXSprint2.Interfaces;
using Projeto_EduXSprint2.Repositories;

namespace Projeto_EduXSprint2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetivoController : ControllerBase
    {
        private readonly IObjetivoRepository objetivoRepository;

        public ObjetivoController()
        {
            objetivoRepository = new ObjetivoRepository();
        }

        #region Get
        /// <summary>
        /// Lista todos os objetivos cadastrados
        /// </summary>
        /// <returns>Objetivos Cadastrados</returns>
        [HttpGet]
       
        public IActionResult Get()
        {
            try
            {
               
                var objetivos = objetivoRepository.Listar();
                if(objetivos == null)
                {
                    return NoContent();
                }

                return Ok(objetivos);

            }
            catch (Exception ex )
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Busca um objetivo atráves de seu Id
        /// </summary>
        /// <param name="id"> id do objetivo desejado</param>
        /// <returns>Objetivo correspondente</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Objetivo objetivo = objetivoRepository.Buscar(id);

                if (objetivo == null)
                {
                    return NotFound();
                }

                return Ok(objetivo);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Post
        /// <summary>
        /// Cadastra novos objetivos no banco de dados
        /// </summary>
        /// <returns>Objetivo adicionado</returns>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] Objetivo objetivo)
        {
            try
            {
                objetivoRepository.AdicionarObjetivo(objetivo);
                return Ok(objetivo);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Put
        /// <summary>
        /// Edita um objetivo cadastrado , inserindo novas informações, depois salva alterações
        /// </summary>
        /// <param name="id">Id do objetivo cadastrado</param>
        /// <param name="objetivo">Novo objetivo a ser inserido</param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id,[FromBody] Objetivo objetivo)
        {
            try
            {
                objetivoRepository.Editar(id ,objetivo);
                return Ok(objetivo);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Delete

        /// <summary>
        /// Deleta objetivos cadastrados
        /// </summary>
        /// <param name="id">Id do objetivo que será deletado</param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var objetivo = objetivoRepository.Buscar(id);
                if(objetivo == null)
                {
                    return NotFound();
                }

                objetivoRepository.Remover(id);
                return Ok(id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}

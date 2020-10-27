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
    public class ObjetivoAlunoController : ControllerBase
    {
        private readonly IObjetivoAlunoRepository objetivoAlunoRepository;

        public ObjetivoAlunoController()
        {
            objetivoAlunoRepository = new ObjetivoAlunoRepository();
        }

        #region Get
        /// <summary>
        /// Lista todas informações cadastradas em ObjetivoAluno
        /// </summary>
        /// <returns>ObjetivoAluno cadastrado</returns>
        [HttpGet]

        public IActionResult Get()
        {
            try
            {

                var objetivosAl = objetivoAlunoRepository.Listar();
                if (objetivosAl == null)
                {
                    return NoContent();
                }

                return Ok(objetivosAl);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Busca um item de ObjetivoAluno atráves de seu Id
        /// </summary>
        /// <param name="id"> id do ObjetivoAluno desejado</param>
        /// <returns>ObjetivoAluno correspondente</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                ObjetivoAluno objetivoAl = objetivoAlunoRepository.Buscar(id);

                if (objetivoAl == null)
                {
                    return NotFound();
                }

                return Ok(objetivoAl);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Post
        /// <summary>
        /// Cadastra novos itens em ObjetivoAluno, no banco de dados
        /// </summary>
        /// <returns>ObjetivoAluno adicionado</returns>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] ObjetivoAluno objetivoAl)
        {
            try
            {
                objetivoAlunoRepository.Adicionar(objetivoAl);
                return Ok(objetivoAl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
        
        #region Put
        /// <summary>
        /// Edita um ObjetivoAluno cadastrado , inserindo novas informações, depois salva alterações
        /// </summary>
        /// <param name="id">Id do ObjetivoAluno cadastrado</param>
        /// <param name="objetivoAl">Novo ObjetivoAluno a ser inserido</param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ObjetivoAluno objetivoAl)
        {
            try
            {
                objetivoAlunoRepository.Editar(id,objetivoAl);
                return Ok(objetivoAl);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Delete

        /// <summary>
        /// Deleta itens ObjetivoAluno cadastrados
        /// </summary>
        /// <param name="id">Id do ObjetivoAluno que será deletado</param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var objetivoAl = objetivoAlunoRepository.Buscar(id);
                if (objetivoAl == null)
                {
                    return NotFound();
                }

                objetivoAlunoRepository.Remover(id);
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

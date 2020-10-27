using System;
using Microsoft.AspNetCore.Mvc;
using Projeto_EduXSprint2.Domains;
using Projeto_EduXSprint2.Repositories;
namespace Projeto_EduXSprint2.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase {
        private readonly TurmaRepository _turmaRepository;

        public TurmaController() {
            _turmaRepository = new TurmaRepository();
        }

        /// <summary>
        /// Olhar Lista do Banco de dados
        /// </summary>
        /// <returns></returns>
        //Fazendo o Get
        [HttpGet]
        public IActionResult Get() {
            try {
                var turma = _turmaRepository.Listar();


                if (turma.Count == 0)
                    return NoContent();

                return Ok(new {
                    totalCount = turma.Count,
                    data = turma
                });
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        
        /// <summary>
        /// Buscar por um id do Banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // Fazendo Get
        [HttpGet("{id}")]
        public IActionResult Get(Guid id) {
            try {
                Turma turma = _turmaRepository.BuscarPorId(id);


                if (turma == null)
                    return NotFound();


                return Ok(turma);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Postar algo no banco
        /// </summary>
        /// <param name="turma"></param>
        /// <returns></returns>
        //fazendo Post
        [HttpPost]
        public IActionResult Post([FromBody] Turma turma) {
            try {

                _turmaRepository.Adicionar(turma);

                return Ok(turma);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Alterar algo nos dados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="turma"></param>
        /// <returns></returns>
        //Fazendo o Put
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Turma turma) {
            try {
                _turmaRepository.Editar(id, turma);

                return Ok(turma);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Remover Algum dado do banco
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //Fazendo Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) {
            try {
                var turma = _turmaRepository.BuscarPorId(id);


                if (turma == null)
                    return NotFound();

                _turmaRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}

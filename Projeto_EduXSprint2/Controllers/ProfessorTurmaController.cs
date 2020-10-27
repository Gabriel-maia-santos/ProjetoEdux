using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_EduXSprint2.Domains;
using Projeto_EduXSprint2.Repositories;

namespace Projeto_EduXSprint2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorTurmaController : ControllerBase
    {
        private readonly ProfessorTurmaRepository _professorTurmaRepository;

        // Fazemos o construtor para instanciarmos o repository
        public ProfessorTurmaController()
        {
            _professorTurmaRepository = new ProfessorTurmaRepository();
        }
        /// <summary>
        /// Lista todos os professores cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de professores</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var professor = _professorTurmaRepository.LerTodos();


                if (professor.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = professor.Count,
                    data = professor
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Busca um professor pelo seu Id
        /// </summary>
        /// <param name="id">Id do professor</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                // Busco o professor pelo id lá no repositorio
                var professor = _professorTurmaRepository.BuscarPorId(id);

                // Aqui nós fazemos uma verificação para saber se esse professor buscado existe. Caso n exista retorna
                // Retorna Notfound- professor n encontrado
                if (professor == null)

                    return NotFound();

                return Ok(professor);
            }
            catch (Exception ex)
            {
                // Caso ocorra algum erro retorna BadRequest e a msg de erro
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Cadastra um professor na sua turma
        /// </summary>
        /// <param name="professorTurma">Objeto do tipo ProfessorTurma</param>
        /// <returns>Retorna o professor cadastrado</returns>
        [HttpPost]
        public IActionResult Post([FromBody] ProfessorTurma professorTurma)// passou como parametro um formulario
        {
            try
            {

                // Adiciona um professor
                _professorTurmaRepository.Cadastrar(professorTurma);

                // retorna ok com os dados do professor cadastrado
                return Ok(professorTurma);
            }
            catch (Exception ex)
            {
                // Caso ocorra algum erro retorna BadRequest e a msg de erro
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Altera um professor
        /// </summary>
        /// <param name="id">Id do Professor</param>
        /// <param name="professorTurma">Objeto do tipo professorTurma</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, ProfessorTurma professorTurma)
        {
            try
            {
                //certamente se ele passou pelo buscar Id ele existe
                _professorTurmaRepository.Alterar(id, professorTurma);

                // retorna ok com os dados do professor alterado
                return Ok(professorTurma);
            }
            catch (Exception ex)
            {
                // Caso ocorra algum erro retorna BadRequest e a msg de erro
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclui um professor
        /// </summary>
        /// <param name="id">Id do professor</param>
        /// <returns>Retorna o professor excluido</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                // Remove o professor pelo id
                _professorTurmaRepository.Excluir(id);

                // em caso de sucesso de sua remoção
                //retorna um ok e mostra o Id 
                return Ok(id);


            }
            catch (Exception ex)
            {

                // Caso ocorra algum erro retorna BadRequest e a msg de erro
                return BadRequest(ex.Message);
            }
        }
    }
}

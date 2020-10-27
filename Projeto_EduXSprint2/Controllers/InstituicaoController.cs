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
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicao _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }
        /// <summary>
        /// Lista todas as instituições que foram cadastradas
        /// </summary>
        /// <returns></returns>
        // GET: api/<PerfilController>
        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                var instituicoes = _instituicaoRepository.LerTodos();

                if (instituicoes.Count == 0)
                    return NoContent();

                return Ok(instituicoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        /// <summary>
        /// Faz a busca pelo Id das instituições
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // GET api/<PerfilController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Instituicao instituicao = _instituicaoRepository.BuscarPorId(id);

                if (instituicao == null)
                    return NotFound();

                return Ok(instituicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        /// <summary>
        /// Faz busca das instituições através destas infos
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="Logradouro"></param>
        /// <param name="Numero"></param>
        /// <param name="Complemento"></param>
        /// <param name="Bairro"></param>
        /// <param name="cidade"></param>
        /// <param name="Uf"></param>
        /// <param name="Cep"></param>
        /// <returns></returns>

        // GET api/<PerfilController>/5
        [HttpGet("Nome, Logradouro, Numero, Complemento, Bairro, cidade, Uf, Cep/{Nome, Logradouro, Numero, Complemento, Bairro, cidade, Uf, Cep}")]
        public IActionResult Get(string Nome, string Logradouro, string Numero, string Complemento, string Bairro, string cidade, string Uf, string Cep)
        {
            try
            {
                var instituicao = _instituicaoRepository.BuscarPorDados(Nome, Logradouro, Numero, Complemento, Bairro, cidade, Uf, Cep);

                if (instituicao == null)
                    return NotFound();

                return Ok(instituicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Cadastra as Instituições
        /// </summary>
        /// <param name="instituicao"></param>
        /// <returns></returns>
        /// 
        // POST api/<PerfilController>
        [HttpPost]
        public IActionResult Post([FromBody] Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Adicionar(instituicao);

                return Ok(instituicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Altera as informações das Instituições cadastradas
        /// </summary>
        /// <param name="id"></param>
        /// <param name="instituicao"></param>
        /// <returns></returns>
        /// 
        // PUT api/<PerfilController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Instituicao instituicao)
        {
            try
            {

                _instituicaoRepository.Alterar(id, instituicao);

                //Retorna Ok com os dados do produto
                return Ok(instituicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclui as Instituições
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
                var instituicao = _instituicaoRepository.BuscarPorId(id);

                if (instituicao == null)
                    return NotFound();

                _instituicaoRepository.Deletar(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

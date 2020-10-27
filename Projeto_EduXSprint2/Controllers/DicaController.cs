using System;
using System.Collections.Generic;
using System.IO;
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
    public class DicaController : ControllerBase
    {
        private readonly DicaRepository _dicaRepository;

        public DicaController()
        {
            _dicaRepository = new DicaRepository();
        }
        /// <summary>
        /// Lista todos as Dicas cadastrados
        /// </summary>
        /// <returns>Retorna a lista de cursos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var dicas = _dicaRepository.LerTodos();

                if (dicas.Count == 0)
                    return NoContent();

                return Ok(dicas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        /// <summary>
        /// Busca uma Dica
        /// </summary>
        /// <param name="id"> Id da Dica</param>
        /// <returns> retorna a Dica cadastrada</returns>
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            try
            {
                // Busca o id da dica pelo id lá no repositorio
                var dica = _dicaRepository.BuscarPorId(id);

                // Aqui nós fazemos uma verificação para saber se esse curso buscado existe. Caso n exista retorna
                // Retorna Notfound- Produto n encontrado
                if (dica == null)

                    return NotFound();

                return Ok(dica);
            }
            catch (Exception ex)
            {
                // Caso ocorra algum erro retorna BadRequest e a msg de erro
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Cadastra uma Dica(imagem)
        /// </summary>
        /// <param name="dica"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Dica dica)// passou como parametro um formulario
        {
            try
            {
                // verifico se foi enviado arquivo com imagem 
                if (dica.Imagem != null)
                {
                    // gero o nome do arquivo unico 
                    // pego a extensao do arquivo 
                    //concateno o nome do arquivo com a extensao 
                    //arquivo.png
                    var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(dica.Imagem.FileName);

                    //GetCurrentDirectory = pega o caminho do dretorio atual, aplicando esta
                    var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwRoot\Upload\Imagens", nomeArquivo);

                    // crio um objeto do tipo FileStream passando o caminho do arquivo 
                    // passa para criar este aquivo 
                    using var streamImagem = new FileStream(caminhoArquivo, FileMode.Create);

                    dica.Imagem.CopyTo(streamImagem);

                    dica.UrlImagem = "http://localhost:44305/Upload/Imagens/" + nomeArquivo;
                }

                // Adiciona uma dica
                _dicaRepository.Adicionar(dica);

                // retorna ok com os dados do curtida cadastrado
                return Ok(dica);
            }
            catch (Exception ex)
            {
                // Caso ocorra algum erro retorna BadRequest e a msg de erro
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Edita uma Dica
        /// </summary>
        /// <param name="id"> Id da Dica</param>
        /// <param name="dica"> Objeto da Dica</param>
        /// <returns> Retorna Dica editada </returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Dica dica)
        {
            try
            {
                //certamente se ele passou pelo buscar Id ele existe
                var dicaTemp = _dicaRepository.BuscarPorId(id);

                // fAZ A verificação do produto
                if (dicaTemp == null)
                    return NotFound();

                // retorna ok com os dados do curtida alterado
                return Ok(dica);
            }
            catch (Exception ex)
            {
                // Caso ocorra algum erro retorna BadRequest e a msg de erro
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Remove uma Dica
        /// </summary>
        /// <param name="id"> Id da Dica</param>
        /// <returns> Retorna Id da Dica removida</returns>
        [HttpDelete("{id}")]
        public IActionResult Remover(Guid id)
        {
            try
            {
                // Remove o produto pelo id
                _dicaRepository.Excluir(id);

                // em caso de sucesso de sua remoção
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

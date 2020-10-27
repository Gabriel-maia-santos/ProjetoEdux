using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_EduXSprint2.Domains;
using Projeto_EduXSprint2.Repositories;
using Projeto_EduXSprint2.Utills;

namespace Projeto_EduXSprint2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os usuarios cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de usuarios</returns>
        [HttpGet]
        public IActionResult Get() // IActionResult vou retornar resultado da minha ação
        {
            // tentar
            try
            {
                // Vamos listar os usuarios do repository
                var usuario = _usuarioRepository.LerTodos();

                // criar uma condição para verificar a existencia desses usuarios, caso n exista retorna
                //No content - Sem conteúdo
                if (usuario.Count == 0)
                    return NoContent();

                //Caso exista retorna ok e os usuarios existentes
                return Ok(new
                {
                    // retornamos mais informações para o nosso frontend como a quantidade de usuarios e seus dados
                    TotalCount = usuario.Count,
                    data = usuario
                });
            }
            // caso
            catch (Exception)
            {
                // to do: Cadastrar mensagem de erro no dominio log erro
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Ocorreu um erro no endpoint Get/produtos. Envie um e-mail para email@gmail.com informando"
                });
            }
        }
        /// <summary>
        /// Busca o usuario pelo seu id
        /// </summary>
        /// <param name="id">id do usuario</param>
        /// <returns>Retorna o usuario buscado</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                // Busco o usuario pelo id lá no repositorio
                Usuario usuario = _usuarioRepository.BuscarPorId(id);

                // Aqui nós fazemos uma verificação para saber se esse usuario buscado existe. Caso n exista retorna
                // Retorna Notfound- usuario n encontrado
                if (usuario == null)

                    return NotFound();

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                // Caso ocorra algum erro retorna BadRequest e a msg de erro
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Busca um usuario pelo seu nome
        /// </summary>
        /// <param name="nome">string do nome</param>
        /// <returns>Retorna o usuario buscado</returns>
        [HttpGet("nome/{nome}")]
        public IActionResult Get(string nome)
        {
            try
            {
                // Busco o usuario pelo id lá no repositorio
                var usuario = _usuarioRepository.BuscarporNome(nome);

                // Aqui nós fazemos uma verificação para saber se esse usuario buscado existe. Caso n exista retorna
                // Retorna Notfound- Produto n encontrado
                if (usuario == null)

                    return NotFound();


                // Caso o usuario exista retorna
                // Ok e seus dados
                return Ok(usuario);

            }
            catch (Exception ex)
            {
                // Caso ocorra algum erro retorna BadRequest e a msg de erro
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Cadastra um usuario
        /// </summary>
        /// <param name="usuario">Objeto do tipo usuario</param>
        /// <returns>Retorna o usuario cadastrado</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)// passou como parametro um formulario
        {
            try
            {
                //usuario.Senha = Crypto.Criptografar(usuario.Senha, usuario.Email.Substring(0, 4));

                // Adiciona um usuario
                _usuarioRepository.Cadastrar(usuario);

                // retorna ok com os dados do usuario cadastrado
                return Ok(usuario);

            }
            catch (Exception ex)
            {
                // Caso ocorra algum erro retorna BadRequest e a msg de erro
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Altera um usuario
        /// </summary>
        /// <param name="id">id do usuario</param>
        /// <param name="usuario">Objeto do tipo usuario</param>
        /// <returns>Retorna o usuario alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Put( Guid id, Usuario usuario)
        {
            try
            {
                //certamente se ele passou pelo buscar Id ele existe
                _usuarioRepository.Alterar(id, usuario);

                // retorna ok com os dados do usuario alterado
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                // Caso ocorra algum erro retorna BadRequest e a msg de erro
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="id">Id do usuario</param>
        /// <returns>Retorna o usuario excluido</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                // Remove o usuario pelo id
                _usuarioRepository.Excluir(id);

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

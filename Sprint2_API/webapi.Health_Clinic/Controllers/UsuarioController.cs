using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using webapi.Health_Clinic.Domains;
using webapi.Health_Clinic.Interfaces;
using webapi.Health_Clinic.Repositories;

namespace webapi.Health_Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuario;

        public UsuarioController()
        {
            _usuario = new UsuarioRepository();
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Cadastrar um Usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize(Roles = "Administrador,Medico,Paciente")]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuario.Cadastrar(usuario);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        ///  Endpoint que aciona o metodo de Buscar um Usuario pelo seu Corpo(email e senha)
        /// </summary>
        /// <param name="email">Email do Usuario</param>
        /// <param name="senha">Senha do Usuario</param>
        /// <returns>Usuario buscado</returns>
        [HttpGet]
        public IActionResult BuscarPorCorpo(string email, string senha)
        {
            try
            {
                return Ok(_usuario.BuscarPorCorpo(email, senha));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        ///  Endpoint que aciona o metodo de Buscar um Usuario pelo seu Id
        /// </summary>
        /// <param name="id">Id do Usuario a ser Buscado</param>
        /// <returns>usuario buscado</returns>
        [HttpGet("{id}")]
       // [Authorize(Roles = "Administrador")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                return Ok(_usuario.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        ///  Endpoint que aciona o metodo de Deletar um Usuario
        /// </summary>
        /// <param name="id">Id do Usuario a ser Deletado</param>
        /// <returns>Status Code</returns>
        [HttpDelete]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                _usuario.Deletar(id);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

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
    public class ComentarioController : ControllerBase
    {
        private IComentarioRepository _comentario;
        public ComentarioController()
        {
            _comentario = new ComentarioRepository();
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Cadastrar um Comentario
        /// </summary>
        /// <param name="comentario">Comentario a ser cadastrado</param>
        /// <returns>Status Code</returns>
        [HttpPost]
        //[Authorize(Roles = "Administrador,Paciente,Medico")]
        public IActionResult Post(Comentario comentario)
        {
            try
            {
                _comentario.Cadastrar(comentario);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Listar os Comentarios
        /// </summary>
        /// <returns>Lista dos Comentarios</returns>
        [HttpGet]
        //[Authorize(Roles = "Administrador,Paciente,Medico")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_comentario.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Deletar um Comentario
        /// </summary>
        /// <param name="id">Id do Comentario a ser Deletado</param>
        /// <returns>Status Code</returns>
        [HttpDelete]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentario.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Buscar comentarios de uma determinada Consulta
        /// </summary>
        /// <param name="id">Id da Consulta a buscar os comentarios dela</param>
        /// <returns>Lista dos Comentarios da Consulta</returns>
        [HttpGet("Consulta")]
        //[Authorize(Roles = "Administrador,Paciente,Medico")]
        public IActionResult BuscarConsulta(Guid id)
        {
            try
            {
                return Ok(_comentario.BuscarPorConsulta(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        
    }
}

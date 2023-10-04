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
    public class ProntuarioController : ControllerBase
    {
        private IProntuarioRepository _prontuario;
        public ProntuarioController()
        {
            _prontuario = new ProntuarioRepository();
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Cadastrar um Prontuario
        /// </summary>
        /// <param name="prontuario"></param>
        /// <returns>Status Code</returns>
        [HttpPost]
        //[Authorize(Roles = "Administrador,Medico")]
        public IActionResult Post(Prontuario prontuario)
        {
            try
            {
                _prontuario.Cadastrar(prontuario);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Listar os Prontuarios
        /// </summary>
        /// <returns>Lista dos prontuarios</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_prontuario.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Atualizar um Prontuario
        /// </summary>
        /// <param name="id">Id do Prontuario a ser Deletado</param>
        /// <param name="prontuario">Prontuario Atualizado</param>
        /// <returns>Status Code</returns>
        [HttpPut]
        //[Authorize(Roles = "Administrador,Medico")]
        public IActionResult Put(Guid id,Prontuario prontuario)
        {
            try
            {
                _prontuario.Atualizar(id,prontuario);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Deletar um Prontuario
        /// </summary>
        /// <param name="id">Id do Prontuario a ser Deletado</param>
        /// <returns>Status Code</returns>
        [HttpDelete]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _prontuario.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Buscar o Prontuario pelo Id da Consulta
        /// </summary>
        /// <param name="idConsulta">Id da Consulta a buscar o seu Prontuario</param>
        /// <returns>Prontuario buscado</returns>
        [HttpGet("Consulta")]
        //[Authorize(Roles = "Administrador,Paciente,Medico")]
        public IActionResult BuscarPorConsulta(Guid idConsulta)
        {
            try
            {
                return Ok(_prontuario.BuscarPorConsulta(idConsulta));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}

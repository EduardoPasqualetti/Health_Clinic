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
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _paciente;
        public PacienteController()
        {
            _paciente = new PacienteRepository();
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Cadastrar um Paciente
        /// </summary>
        /// <param name="paciente">Paciente a ser Cadastrado</param>
        /// <returns>Status Code</returns>
        [HttpPost]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Post(Paciente paciente)
        {
            try
            {
                _paciente.Cadastrar(paciente);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Listar os Pacientes
        /// </summary>
        /// <returns>Lista dos Pacientes</returns>
        [HttpGet]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_paciente.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Atualizar um Paciente
        /// </summary>
        /// <param name="id">Id do Paciente a ser Atualizado</param>
        /// <param name="paciente">Paciente Atualizado</param>
        /// <returns>Status Code</returns>
        [HttpPut]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Put(Guid id,Paciente paciente)
        {
            try
            {
                _paciente.Atualizar(id, paciente);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Deletar um Paciente
        /// </summary>
        /// <param name="id">Id do Paciente a ser Deletado</param>
        /// <returns>Status Code</returns>
        [HttpDelete]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _paciente.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Buscar um Paciente pelo seu Id
        /// </summary>
        /// <param name="id">Id do paciente a ser Buscado</param>
        /// <returns>Paciente Buscado</returns>
        [HttpGet("{id}")]
        //[Authorize(Roles = "Administrador,Medico")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                return Ok(_paciente.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}

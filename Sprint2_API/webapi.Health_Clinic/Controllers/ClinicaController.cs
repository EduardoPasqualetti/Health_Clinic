using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Health_Clinic.Domains;
using webapi.Health_Clinic.Interfaces;
using webapi.Health_Clinic.Repositories;

namespace webapi.Health_Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _clinica;

        public ClinicaController()
        {
            _clinica = new ClinicaRepository();
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Cadastrar uma Clinica
        /// </summary>
        /// <param name="clinica">Clinica a ser cadastrada</param>
        /// <returns>Status Code</returns>
        [HttpPost]
        //[Authorize(Roles ="Administrador")]
        public IActionResult Post(Clinica clinica)
        {
            try
            {
                _clinica.Cadastrar(clinica);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Listar Clinicas
        /// </summary>
        /// <returns>Lista da Clinicas</returns>
        [HttpGet]
        //[Authorize(Roles = "Administrador,Medico,Paciente")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_clinica.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Atualizar os dados de uma Clinica
        /// </summary>
        /// <param name="id">Id da Clinica a ser Atualizada</param>
        /// <param name="clinica">Clinica atualizada</param>
        /// <returns>Status Code</returns>
        [HttpPut]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Put(Guid id, Clinica clinica)
        {
            try
            {
                _clinica.Atualizar(id, clinica);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Deletar uma Clinica
        /// </summary>
        /// <param name="id">Id da Clinica a ser deletada</param>
        /// <returns>Status code</returns>
        [HttpDelete]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _clinica.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Buscar uma Clinica pelo seu Id
        /// </summary>
        /// <param name="id">Id da Clinica a ser buscada</param>
        /// <returns>Clinica Encontrada</returns>
        [HttpGet("{id}")]
        //[Authorize(Roles = "Administrador,Medico,Paciente")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                return Ok(_clinica.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}

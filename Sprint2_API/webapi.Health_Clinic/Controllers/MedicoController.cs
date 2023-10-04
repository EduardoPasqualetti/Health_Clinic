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
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _medico;
        public MedicoController()
        {
            _medico = new MedicoRepository();
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Cadastrar um Medico
        /// </summary>
        /// <param name="medico">Medico a ser Cadastrado</param>
        /// <returns>Status Code</returns>
        [HttpPost]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Post(Medico medico)
        {
            try
            {
                _medico.Cadastrar(medico);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Listar os Medicos
        /// </summary>
        /// <returns>Lista dos Medicos</returns>
        [HttpGet]
        //[Authorize(Roles = "Administrador,Medico")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_medico.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Atualizar um Medico
        /// </summary>
        /// <param name="id">Id do medico a ser Atualizado</param>
        /// <param name="medico">MEdico Atualizado</param>
        /// <returns>Status Code</returns>
        [HttpPut]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Put(Guid id, Medico medico)
        {
            try
            {
                _medico.Atualizar(id, medico);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Deletar um Medico
        /// </summary>
        /// <param name="id">Id do Medico a ser Deletado</param>
        /// <returns>Status Code</returns>
        [HttpDelete]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _medico.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Buscar um medico pelo seu Id
        /// </summary>
        /// <param name="id">Id do Medico a ser buscado</param>
        /// <returns>Medico buscado</returns>
        [HttpGet("{id}")]
        //[Authorize(Roles = "Administrador,Medico")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                return Ok(_medico.BuscarPorId(id));

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}

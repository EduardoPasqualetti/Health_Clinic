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
    public class StatusController : ControllerBase
    {
        private IStatusRepository _status;
        public StatusController()
        {
            _status = new StatusRepository();
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Cadastrar um Status
        /// </summary>
        /// <param name="status">Status Cadastrado</param>
        /// <returns>Status Code</returns>
        [HttpPost]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Post(Status status)
        {
            try
            {
                _status.Cadastrar(status);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Listar os Status
        /// </summary>
        /// <returns>Lista dos Status</returns>
        [HttpGet]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_status.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Atualizar um Status
        /// </summary>
        /// <param name="id">Id do Status a ser Atualizado</param>
        /// <param name="status">Status Atualizado</param>
        /// <returns>Status Code</returns>
        [HttpPut]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Put(Guid id,Status status)
        {
            try
            {
                _status.Atualizar(id, status);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Deletar um Status
        /// </summary>
        /// <param name="id">Id do Status a ser Deletado</param>
        /// <returns>Status Code</returns>
        [HttpDelete]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _status.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}

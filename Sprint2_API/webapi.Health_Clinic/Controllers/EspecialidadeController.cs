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
    public class EspecialidadeController : ControllerBase
    {
        private IEspecialidadeRepository _especialidade;

        public EspecialidadeController()
        {
            _especialidade = new EspecialidadeRepository();
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Cadastrar uma Especialidade
        /// </summary>
        /// <param name="especialidade">Especialidade a ser cadastrada</param>
        /// <returns>Status Code</returns>
        [HttpPost]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Post(Especialidade especialidade)
        {
            try
            {
                _especialidade.Cadastrar(especialidade);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Listar as Especialidades
        /// </summary>
        /// <returns>Lista das Especialidades</returns>
        [HttpGet]
        //[Authorize(Roles = "Administrador,Medico,Paciente")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_especialidade.Listar()); 
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Atualizar uma Especialidade
        /// </summary>
        /// <param name="id">Id da Especialidade a ser Atualizada</param>
        /// <param name="especialidade">Especialidade Atualizada</param>
        /// <returns>Status Code</returns>
        [HttpPut]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Put(Guid id,Especialidade especialidade)
        {
            try
            {
                _especialidade.Atualizar(id, especialidade);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Endpoint que aciona o metodo de Deletar uma Especialidade
        /// </summary>
        /// <param name="id">Id da Especialidade a ser Deletada</param>
        /// <returns>Status Code</returns>
        [HttpDelete]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _especialidade.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}

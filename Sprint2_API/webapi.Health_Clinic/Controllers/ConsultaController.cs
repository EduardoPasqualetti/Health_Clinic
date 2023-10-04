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
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consulta;
        public ConsultaController()
        {
            _consulta = new ConsultaRepository();
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Cadastrar uma Consulta
        /// </summary>
        /// <param name="consulta">Consulta a ser Cadastrada</param>
        /// <returns>Status Code</returns>
        [HttpPost]
        //[Authorize(Roles = "Administrador")]
        public  IActionResult Post(Consulta consulta)
        {
            try
            {
                _consulta.Cadastrar(consulta);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de Listar as Consultas
        /// </summary>
        /// <returns>Lista das Consultas</returns>
        [HttpGet]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_consulta.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        ///  Endpoint que aciona o metodo de Atualizar uma Consulta
        /// </summary>
        /// <param name="id">Id da clinica a ser Atualizada</param>
        /// <param name="consulta">Clinica Atualizada</param>
        /// <returns>Status Code</returns>
        [HttpPut]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Put(Guid id,Consulta consulta)
        {
            try
            {
                _consulta.Atualizar(id, consulta);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        ///  Endpoint que aciona o metodo de Deletar uma Consulta
        /// </summary>
        /// <param name="id">Id da consulta a ser Deletada</param>
        /// <returns>Status Code</returns>
        [HttpDelete]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _consulta.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        ///  Endpoint que aciona o metodo de Listar as Consultas realizadas por um determinado medico
        /// </summary>
        /// <param name="IdMedico">Id do Medico a buscar suas consultas</param>
        /// <returns>Lista das consultas de um Medico</returns>
        [HttpGet("Medico")]
        //[Authorize(Roles = "Administrador,Medico")]
        public IActionResult ListarPorMedico(Guid IdMedico)
        {
            try
            {
                return Ok(_consulta.BuscarPorMedico(IdMedico));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        ///  Endpoint que aciona o metodo de Listar as Consultas de um determinado paciente
        /// </summary>
        /// <param name="id">Id do paciente a buscar suas consultas</param>
        /// <returns>Lista das consultas de um Paciente</returns>
        [HttpGet("Paciente")]
        //[Authorize(Roles = "Administrador,Paciente,Medico")]
        public IActionResult ListarPacientes(Guid id)
        {
            try
            {
                return Ok(_consulta.BuscarPorPaciente(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}

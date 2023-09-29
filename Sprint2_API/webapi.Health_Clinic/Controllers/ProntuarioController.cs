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
    public class ProntuarioController : ControllerBase
    {
        private IProntuarioRepository _prontuario;
        public ProntuarioController()
        {
            _prontuario = new ProntuarioRepository();
        }

        [HttpPost]
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


        [HttpPut]
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

        [HttpDelete]
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

        [HttpGet]
        public IActionResult BuscarPorConsulta(Guid id)
        {
            try
            {
                return Ok(_prontuario.BuscarPorConsulta(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}

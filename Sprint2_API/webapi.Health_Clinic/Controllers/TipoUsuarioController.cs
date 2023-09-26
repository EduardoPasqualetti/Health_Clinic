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
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuario;

        public TipoUsuarioController()
        {
            _tipoUsuario = new TipoUsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(TipoUsuario tp)
        {
            try
            {
                _tipoUsuario.Cadastrar(tp);
                return StatusCode(201);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoUsuario.Listar());
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public IActionResult Put(Guid id,TipoUsuario tp)
        {
            try
            {
                _tipoUsuario.Atualizar(id, tp);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoUsuario.Deletar(id);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

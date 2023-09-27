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
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _medico;
        public MedicoController()
        {
            _medico = new MedicoRepository();
        }

        [HttpPost]
        public IActionResult Post(Medico medico)
        {
            try
            {
                _medico.Cadastrar(medico);
                return StatusCode(201);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

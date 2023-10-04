using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.Health_Clinic.Domains;
using webapi.Health_Clinic.Interfaces;
using webapi.Health_Clinic.LoginViewmodel;
using webapi.Health_Clinic.Repositories;

namespace webapi.Health_Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuario;

        public LoginController()
        {
            _usuario = new UsuarioRepository();
        }


        /// <summary>
        /// Endpoint que aciona o metodo de Login
        /// </summary>
        /// <param name="usuario">Usuario que ira fazer o Logn</param>
        /// <returns>Token de Login</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario user = _usuario.BuscarPorCorpo(usuario.Email!, usuario.Senha!);

                if (usuario == null)
                {
                    return NotFound("Email ou Senha invalidos!");
                }

                //Logica do token

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                    new Claim(JwtRegisteredClaimNames.Jti, user.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role,user.TipoUsuario!.Titulo!)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Clinic-chave-autenticacao-webapi-dev"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                (
                    issuer: "webapi.Health_Clinic",
                    audience: "webapi.Health_Clinic",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: creds
                );


                // 5 parte - retornar o token criado
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ERRO)
            {
                return BadRequest(ERRO.Message);
            }
        }
    }
}

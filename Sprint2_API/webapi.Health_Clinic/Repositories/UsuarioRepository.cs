using webapi.Health_Clinic.Contexts;
using webapi.Health_Clinic.Domains;
using webapi.Health_Clinic.Interfaces;
using webapi.Health_Clinic.Utils;

namespace webapi.Health_Clinic.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ClinicContext _Context;

        public UsuarioRepository()
        {
            _Context = new ClinicContext();
        }
        public Usuario BuscarPorCorpo(string email, string senha)
        {
            Usuario usuario = _Context.Usuario
                 .Select(u => new Usuario
                 {
                     IdUsuario = u.IdUsuario,
                     Email = u.Email,
                     Senha = u.Senha,
                     IdTipoUsuario= u.IdTipoUsuario,
                     TipoUsuario = new TipoUsuario
                     {
                         IdTipoUsuario= u.IdTipoUsuario,
                         Titulo = u.TipoUsuario!.Titulo
                     }
                 }).FirstOrDefault(u => u.Email == email)!;

            if (usuario != null)
            {
                bool confere = Criptografia.CompararHash(senha, usuario.Senha!);

                if (confere)
                {
                    return usuario;
                }
            }
            return null!;
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuario = _Context.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Email = u.Email,
                        IdTipoUsuario = u.IdTipoUsuario,
                        TipoUsuario = new TipoUsuario
                        {
                            IdTipoUsuario = u.IdTipoUsuario,
                            Titulo = u.TipoUsuario!.Titulo
                        }
                    }).FirstOrDefault(u => u.IdUsuario == id)!;

                if (usuario != null)
                {
                    return usuario;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Cadastrar(Usuario usuario)
        {
            usuario.IdUsuario = Guid.NewGuid();

            usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

            _Context.Usuario.Add(usuario);
            _Context.SaveChanges();

        }
    }
}

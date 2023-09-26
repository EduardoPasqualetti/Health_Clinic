using webapi.Health_Clinic.Domains;
using webapi.Health_Clinic.Interfaces;

namespace webapi.Health_Clinic.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuario BuscarPorCorpo(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}

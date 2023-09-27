using webapi.Health_Clinic.Contexts;
using webapi.Health_Clinic.Domains;
using webapi.Health_Clinic.Interfaces;

namespace webapi.Health_Clinic.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly ClinicContext _Context;

        public ComentarioRepository()
        {
            _Context = new ClinicContext();
        }
        public Comentario BuscarPorConsulta(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Comentario comentario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Comentario> Listar()
        {
            throw new NotImplementedException();
        }
    }
}

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

        public List<Comentario> BuscarPorConsulta(Guid id)
        {
            Comentario comentario = new Comentario();
            if (comentario.IdConsulta == id)
            {
                return _Context.Comentario.ToList();
            }
            return null!;
        }

        public void Cadastrar(Comentario comentario)
        {
            comentario.IdComentario = Guid.NewGuid();
            _Context.Comentario.Add(comentario);
            _Context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Comentario  buscado =_Context.Comentario.Find(id)!;
            _Context.Comentario.Remove(buscado);
            _Context.SaveChanges();

        }

        public List<Comentario> Listar()
        {
            return _Context.Comentario.ToList();
        }
    }
}

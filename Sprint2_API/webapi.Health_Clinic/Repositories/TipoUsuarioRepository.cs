using webapi.Health_Clinic.Contexts;
using webapi.Health_Clinic.Domains;
using webapi.Health_Clinic.Interfaces;

namespace webapi.Health_Clinic.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly ClinicContext _Context;
        public TipoUsuarioRepository()
        {
            _Context = new ClinicContext();
        }
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            TipoUsuario buscado = _Context.TipoUsuario.Find(id)!;
            if (buscado != null)
            {
                buscado.Titulo = tipoUsuario.Titulo;
            }
            _Context.Update(buscado!);
            _Context.SaveChanges();
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            tipoUsuario.IdTipoUsuario = Guid.NewGuid();
            _Context.TipoUsuario.Add(tipoUsuario);
            _Context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TipoUsuario buscado = _Context.TipoUsuario.Find(id)!;
            _Context.TipoUsuario.Remove(buscado!);
            _Context.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return _Context.TipoUsuario.ToList();
        }
    }
}

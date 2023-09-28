using webapi.Health_Clinic.Contexts;
using webapi.Health_Clinic.Domains;
using webapi.Health_Clinic.Interfaces;

namespace webapi.Health_Clinic.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly ClinicContext _Context;

        public StatusRepository()
        {
            _Context = new ClinicContext();
        }
        public void Atualizar(Guid id, Status status)
        {
            Status buscado = _Context.Status.Find(id)!;
            if (buscado != null)
            {
                buscado.StatusConsulta = status.StatusConsulta;
            }
            _Context.Status.Update(buscado!);
            _Context.SaveChanges();
        }

        public void Cadastrar(Status status)
        {
            status.IdStatus = Guid.NewGuid();
            _Context.Status.Add(status);
            _Context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Status buscado=_Context.Status.Find(id)!;
            _Context.Status.Remove(buscado);
            _Context.SaveChanges();

        }

        public List<Status> Listar()
        {
            return _Context.Status.ToList();
        }
    }
}

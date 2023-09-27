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
            throw new NotImplementedException();
        }

        public void Cadastrar(Status status)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Status> Listar()
        {
            throw new NotImplementedException();
        }
    }
}

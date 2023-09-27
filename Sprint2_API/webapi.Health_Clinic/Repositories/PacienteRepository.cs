using webapi.Health_Clinic.Contexts;
using webapi.Health_Clinic.Domains;
using webapi.Health_Clinic.Interfaces;

namespace webapi.Health_Clinic.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ClinicContext _Context;

        public PacienteRepository()
        {
            _Context = new ClinicContext();
        }
        public void Atualizar(Guid id, Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Paciente> Listar()
        {
            throw new NotImplementedException();
        }
    }
}

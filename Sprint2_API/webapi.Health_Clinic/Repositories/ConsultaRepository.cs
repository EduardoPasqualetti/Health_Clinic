using webapi.Health_Clinic.Contexts;
using webapi.Health_Clinic.Domains;
using webapi.Health_Clinic.Interfaces;

namespace webapi.Health_Clinic.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly ClinicContext _Context;

        public ConsultaRepository()
        {
            _Context = new ClinicContext();
        }
        public void Atualizar(Guid id, Consulta consulta)
        {
            throw new NotImplementedException();
        }

        public Consulta BuscarPorMedico(Guid id)
        {
            throw new NotImplementedException();
        }

        public Consulta BuscarPorPaciente(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Consulta consulta)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Consulta> Listar()
        {
            throw new NotImplementedException();
        }
    }
}

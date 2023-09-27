using webapi.Health_Clinic.Contexts;
using webapi.Health_Clinic.Domains;
using webapi.Health_Clinic.Interfaces;

namespace webapi.Health_Clinic.Repositories
{
    public class ProntuarioRepository : IProntuarioRepository
    {
        private readonly ClinicContext _Context;

        public ProntuarioRepository()
        {
            _Context = new ClinicContext();
        }
        public void Atualizar(Guid id, Prontuario prontuario)
        {
            throw new NotImplementedException();
        }

        public Prontuario BuscarPorConsulta(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Prontuario prontuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Prontuario> Listar()
        {
            throw new NotImplementedException();
        }
    }
}

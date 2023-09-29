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
            Consulta buscada = _Context.Consulta.Find(id)!;
            if (buscada != null)
            {
                buscada.Data = consulta.Data;
                buscada.Horario= consulta.Horario;
                buscada.IdMedico= consulta.IdMedico;
                buscada.IdStatus = consulta.IdStatus;  
            }
            _Context.Consulta.Update(consulta);
            _Context.SaveChanges();
        }

        public List<Consulta> BuscarPorMedico(Guid id)
        {
            Consulta consulta = new Consulta();
            if (consulta.IdMedico == id)
            {
                return _Context.Consulta.ToList();
            }
            return null!;
        }

        public List<Consulta> BuscarPorPaciente(Guid id)
        {
            Consulta consulta = new Consulta();
            if (consulta.IdPaciente == id)
            {
                return _Context.Consulta.ToList();
            }
            return null!;
        }

        public void Cadastrar(Consulta consulta)
        {
            consulta.IdConsulta = Guid.NewGuid();
            _Context.Consulta.Add(consulta);
            _Context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Consulta buscada =_Context.Consulta.Find(id)!;
            _Context.Consulta.Remove(buscada);
            _Context.SaveChanges();
        }

        public List<Consulta> Listar()
        {
            return _Context.Consulta.ToList();
        }

    }
}

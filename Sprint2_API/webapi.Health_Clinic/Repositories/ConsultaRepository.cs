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
            return _Context.Consulta.Where(u => u.IdMedico == id).Select(u => new Consulta
            {
                IdConsulta = u.IdConsulta,
                Data=u.Data,
                Horario=u.Horario,
                IdMedico=u.IdMedico,
                Medico = new Medico
                {
                    IdMedico=u.Medico!.IdMedico,
                    Nome=u.Medico.Nome,
                    CRM=u.Medico.CRM,
                    IdEspecialidade=u.Medico.IdEspecialidade,
                    Especialidade = new Especialidade
                    {
                        IdEspecialidade=u.Medico.Especialidade!.IdEspecialidade,
                        Titulo=u.Medico.Especialidade.Titulo,
                    },
                    IdUsuario=u.Medico.IdUsuario,
                    IdClinica=u.Medico.IdClinica,

                },
                IdPaciente=u.IdPaciente,
                Paciente = new Paciente
                {
                    IdPaciente=u.Paciente!.IdPaciente,
                    Nome=u.Paciente.Nome,
                    CPF=u.Paciente.CPF,
                    Telefone=u.Paciente.Telefone,
                    DataDeNascimento=u.Paciente.DataDeNascimento,
                    IdUsuario=u.Paciente.IdUsuario,
                },
                IdStatus=u.IdStatus,
                Status = new Status
                {
                    IdStatus=u.Status!.IdStatus,
                    StatusConsulta=u.Status.StatusConsulta,
                }

            }).ToList();
        }

        public List<Consulta> BuscarPorPaciente(Guid id)
        {
            return _Context.Consulta.Where(u => u.IdPaciente == id).Select(u => new Consulta
            {
                IdConsulta = u.IdConsulta,
                Data = u.Data,
                Horario = u.Horario,
                IdMedico = u.IdMedico,
                Medico = new Medico
                {
                    IdMedico = u.Medico!.IdMedico,
                    Nome = u.Medico.Nome,
                    CRM = u.Medico.CRM,
                    IdEspecialidade = u.Medico.IdEspecialidade,
                    Especialidade = new Especialidade
                    {
                        IdEspecialidade = u.Medico.Especialidade!.IdEspecialidade,
                        Titulo = u.Medico.Especialidade.Titulo,
                    },
                    IdUsuario = u.Medico.IdUsuario,
                    IdClinica = u.Medico.IdClinica,

                },
                IdPaciente = u.IdPaciente,
                Paciente = new Paciente
                {
                    IdPaciente = u.Paciente!.IdPaciente,
                    Nome = u.Paciente.Nome,
                    CPF = u.Paciente.CPF,
                    Telefone = u.Paciente.Telefone,
                    DataDeNascimento = u.Paciente.DataDeNascimento,
                    IdUsuario = u.Paciente.IdUsuario,
                },
                IdStatus = u.IdStatus,
                Status = new Status
                {
                    IdStatus = u.Status!.IdStatus,
                    StatusConsulta = u.Status.StatusConsulta,
                }

            }).ToList();
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

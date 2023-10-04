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
            Paciente buscado = _Context.Paciente.Find(id)!;
            if (buscado != null)
            {
                buscado.Nome = paciente.Nome;
                buscado.CPF = paciente.CPF;
                buscado.Telefone = paciente.Telefone;
                buscado.DataDeNascimento = paciente.DataDeNascimento;
            }
            _Context.Paciente.Update(buscado!);
            _Context.SaveChanges();
        }

        public Paciente BuscarPorId(Guid id)
        {
           Paciente buscado = _Context.Paciente.Select(u => new Paciente
           {
               IdPaciente=u.IdPaciente,
               Nome=u.Nome,
               CPF=u.CPF,
               Telefone=u.Telefone,
               DataDeNascimento=u.DataDeNascimento,
               IdUsuario = u.IdUsuario,
               Usuario= new Usuario
               {
                   IdUsuario=u.IdUsuario,
                   Email=u.Usuario.Email,
               }

           }).FirstOrDefault(x => x.IdPaciente== id)!;
            if (buscado != null)
            {
                return buscado;
            }
            return null!;
        }

        public void Cadastrar(Paciente paciente)
        {

            paciente.IdPaciente = Guid.NewGuid();
            _Context.Paciente.Add(paciente);
            _Context.SaveChanges();


        }

        public void Deletar(Guid id)
        {
            Paciente buscado = _Context.Paciente.Find(id)!;
            _Context.Paciente.Remove(buscado!);
            _Context.SaveChanges();

        }

        public List<Paciente> Listar()
        {
            return _Context.Paciente.ToList();
        }
    }
}

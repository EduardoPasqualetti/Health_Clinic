using webapi.Health_Clinic.Contexts;
using webapi.Health_Clinic.Domains;
using webapi.Health_Clinic.Interfaces;

namespace webapi.Health_Clinic.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ClinicContext _Context;

        public MedicoRepository()
        {
            _Context = new ClinicContext();
        }
        public void Atualizar(Guid id, Medico medico)
        {
            Medico buscado = _Context.Medico.Find(id)!;
            if (buscado != null)
            {
                buscado.Nome = medico.Nome;
                buscado.CRM = medico.CRM;
                buscado.IdEspecialidade= medico.IdEspecialidade;
                buscado.IdClinica = medico.IdClinica;
            }
            _Context.Medico.Update(buscado!);
            _Context.SaveChanges();
        }

        public Medico BuscarPorId(Guid id)
        {
            Medico buscado = _Context.Medico.Select(u => new Medico
            {
                IdMedico = u.IdMedico,
                Nome= u.Nome,
                CRM= u.CRM,
                IdEspecialidade= u.IdEspecialidade,
                Especialidade =new Especialidade
                {
                    IdEspecialidade= u.IdEspecialidade,
                    Titulo= u.Especialidade!.Titulo
                },
                IdClinica=u.IdClinica,
                Clinica= new Clinica
                {
                    IdClinica=u.IdClinica,
                    NomeFantasia= u.Clinica!.NomeFantasia,
                    CNPJ=u.Clinica.CNPJ,
                    Endereco=u.Clinica!.Endereco,
                    RazaoSocial=u.Clinica!.RazaoSocial,
                    HorarioAbertura=u.Clinica.HorarioAbertura,
                    HorarioFechamento=u.Clinica.HorarioFechamento,
                },
                IdUsuario=u.IdUsuario,
                Usuario= new Usuario
                {
                    IdUsuario=u.IdUsuario,
                    Email=u.Usuario!.Email,
                }
                
            }).FirstOrDefault(x => x.IdMedico == id)!;
            if (buscado != null)
            {
                return buscado;
            }
            return null!;
        }

        public void Cadastrar(Medico medico)
        {

            medico.IdMedico = Guid.NewGuid();
            _Context.Medico.Add(medico);
            _Context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Medico buscado = _Context.Medico.Find(id)!;
            _Context.Medico.Remove(buscado);
            _Context.SaveChanges();
        }

        public List<Medico> Listar()
        {
            return _Context.Medico.ToList();
        }
    }
}

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
            Medico buscado = _Context.Medico.Find(id);
            if (buscado != null)
            {
                buscado.Nome= medico.Nome;
                buscado.CRM = medico.CRM;
                buscado.IdClinica= medico.IdClinica;
            }
            _Context.Medico.Update(buscado);
            _Context.SaveChanges();
        }

        public void Cadastrar(Medico medico)
        {        
            TipoUsuario tipoUsuario = new TipoUsuario();
            if (tipoUsuario.Titulo == "Medico")
            {
                medico.IdMedico = Guid.NewGuid();
                _Context.Medico.Add(medico);
                _Context.SaveChanges();
            }
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

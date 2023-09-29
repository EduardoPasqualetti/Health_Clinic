using webapi.Health_Clinic.Contexts;
using webapi.Health_Clinic.Domains;
using webapi.Health_Clinic.Interfaces;

namespace webapi.Health_Clinic.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly ClinicContext _Context;
        public ClinicaRepository()
        {
            _Context = new ClinicContext();
        }
        public void Atualizar(Guid id, Clinica clinica)
        {
            Clinica buscada = _Context.Clinica.Find(id)!;
            if (buscada != null)
            {
                buscada!.NomeFantasia = clinica.NomeFantasia;
                buscada.RazaoSocial = clinica.RazaoSocial;
                buscada.CNPJ = clinica.CNPJ;
                buscada.HorarioAbertura = clinica.HorarioAbertura;
                buscada.HorarioFechamento = clinica.HorarioFechamento;
                buscada.Endereco = clinica.Endereco;
            }
            _Context.Clinica.Update(buscada!);
            _Context.SaveChanges();
        }

        public Clinica BuscarPorId(Guid id)
        {
            Clinica buscado = _Context.Clinica.FirstOrDefault(x => x.IdClinica == id)!;
            if (buscado != null)
            {
                return buscado;
            }
            return null!;
        }

        public void Cadastrar(Clinica clinica)
        {
            clinica.IdClinica = Guid.NewGuid();
            _Context.Clinica.Add(clinica);
            _Context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Clinica buscada = _Context.Clinica.Find(id)!;
            _Context.Clinica.Remove(buscada);
            _Context.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return _Context.Clinica.ToList();
        }
    }
}

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
            Prontuario buscado =_Context.Prontuario.Find(id)!;
            if (buscado != null)
            {
                buscado.Descricao = prontuario.Descricao;
            }
            _Context.Prontuario.Update(buscado!);
            _Context.SaveChanges();
        }

        public List<Prontuario> BuscarPorConsulta(Guid id)
        {
            Prontuario prontuario = new Prontuario();
            if (prontuario.IdConsulta == id)
            {
                return _Context.Prontuario.ToList();
            }
            return null!;
        }

        public void Cadastrar(Prontuario prontuario)
        {
            prontuario.IdProntuario = Guid.NewGuid();
            _Context.Prontuario.Add(prontuario);
            _Context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Prontuario buscado = _Context.Prontuario.Find(id)!;
            _Context.Prontuario.Remove(buscado!);
            _Context.SaveChanges();
        }

    }
}

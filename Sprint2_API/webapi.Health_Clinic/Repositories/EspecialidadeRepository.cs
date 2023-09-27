using webapi.Health_Clinic.Contexts;
using webapi.Health_Clinic.Domains;
using webapi.Health_Clinic.Interfaces;

namespace webapi.Health_Clinic.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly ClinicContext _Context;

        public EspecialidadeRepository()
        {
            _Context = new ClinicContext();
        }
        public void Atualizar(Guid id, Especialidade especialidade)
        {
            Especialidade buscado = _Context.Especialidade.Find(id)!;
            if (buscado != null)
            {
                buscado!.Titulo = especialidade.Titulo;
            }
            _Context.Especialidade.Update(buscado);
            _Context.SaveChanges();
        }

        public void Cadastrar(Especialidade especialidade)
        {
            especialidade.IdEspecialidade = Guid.NewGuid();
            _Context.Especialidade.Add(especialidade);
            _Context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Especialidade buscado = _Context.Especialidade.Find(id)!;
            _Context.Especialidade.Remove(buscado);
            _Context.SaveChanges();
        }

        public List<Especialidade> Listar()
        {
            return _Context.Especialidade.ToList();
        }
    }
}

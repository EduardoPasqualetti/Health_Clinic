using webapi.Health_Clinic.Domains;

namespace webapi.Health_Clinic.Interfaces
{
    public interface IEspecialidadeRepository
    {
        void Cadastrar(Especialidade especialidade);
        List<Especialidade> Listar();
        void Atualizar(Guid id, Especialidade especialidade);
        void Deletar(Guid id);
    }
}

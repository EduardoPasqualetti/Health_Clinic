using webapi.Health_Clinic.Domains;

namespace webapi.Health_Clinic.Interfaces
{
    public interface IStatusRepository
    {
        void Cadastrar(Status status);
        List<Status> Listar();
        void Atualizar(Guid id, Status status);
        void Deletar(Guid id);
    }
}

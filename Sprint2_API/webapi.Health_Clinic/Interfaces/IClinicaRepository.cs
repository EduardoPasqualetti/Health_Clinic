using webapi.Health_Clinic.Domains;

namespace webapi.Health_Clinic.Interfaces
{
    public interface IClinicaRepository
    {
        void Cadastrar(Clinica clinica);
        List<Clinica> Listar();
        void Atualizar(Guid id, Clinica clinica);
        void Deletar(Guid id);
        Clinica BuscarPorId(Guid id);
    }
}

using webapi.Health_Clinic.Domains;

namespace webapi.Health_Clinic.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente paciente);
        List<Paciente> Listar();
        void Atualizar(Guid id, Paciente paciente);
        void Deletar(Guid id);

        Paciente BuscarPorId(Guid id);
    }
}

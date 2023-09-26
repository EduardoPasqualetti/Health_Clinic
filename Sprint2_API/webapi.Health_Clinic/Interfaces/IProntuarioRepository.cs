using webapi.Health_Clinic.Domains;

namespace webapi.Health_Clinic.Interfaces
{
    public interface IProntuarioRepository
    {
        void Cadastrar(Prontuario prontuario);
        List<Prontuario> Listar();
        void Atualizar(Guid id, Prontuario prontuario);
        void Deletar(Guid id);
        Prontuario BuscarPorConsulta(Guid id);
    }
}

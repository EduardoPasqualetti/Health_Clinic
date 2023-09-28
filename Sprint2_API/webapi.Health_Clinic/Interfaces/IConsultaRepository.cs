using webapi.Health_Clinic.Domains;

namespace webapi.Health_Clinic.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta consulta);
        List<Consulta> Listar();
        void Atualizar(Guid id, Consulta consulta);
        void Deletar(Guid id);
        List<Consulta> BuscarPorMedico(Guid id);
        List<Consulta> BuscarPorPaciente(Guid id);
    }
}

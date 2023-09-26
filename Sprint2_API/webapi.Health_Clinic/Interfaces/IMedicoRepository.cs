using webapi.Health_Clinic.Domains;

namespace webapi.Health_Clinic.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico medico);
        List<Medico> Listar();
        void Atualizar(Guid id,Medico medico);
        void Deletar(Guid id);
    }
}

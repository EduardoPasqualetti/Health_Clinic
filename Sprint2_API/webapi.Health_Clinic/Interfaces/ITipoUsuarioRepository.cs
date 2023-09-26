using webapi.Health_Clinic.Domains;

namespace webapi.Health_Clinic.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        void Cadastrar(TipoUsuario tipoUsuario);
        List<TipoUsuario> Listar();
        void Atualizar(Guid id, TipoUsuario tipoUsuario);
        void Deletar(Guid id);
    }
}

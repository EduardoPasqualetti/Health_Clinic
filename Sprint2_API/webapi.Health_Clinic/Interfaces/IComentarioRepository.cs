using webapi.Health_Clinic.Domains;

namespace webapi.Health_Clinic.Interfaces
{
    public interface IComentarioRepository
    {
        void Cadastrar(Comentario comentario);
        List<Comentario> Listar();
        void Deletar(Guid id);
        List<Comentario> BuscarPorConsulta(Guid id);
    }
}

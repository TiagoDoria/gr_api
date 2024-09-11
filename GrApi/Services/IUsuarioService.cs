using GrApi.DTO;

namespace GrApi.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> Register(UsuarioDTO request);
        Task<IEnumerable<UsuarioDTO>> ListarTodos();
        Task<UsuarioDTO> ListarID(string id);
        Task<bool> Login(UsuarioLoginDTO request);
        Task<UsuarioDTO> Update(UsuarioDTO request);
    }
}

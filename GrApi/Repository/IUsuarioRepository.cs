using GrApi.Models;

namespace GrApi.Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> FindAllAsync();
        Task<Usuario> FindByIdAsync(string id);
        Task<bool> FindUserAsync(string email, string passworf);
        Task<Usuario> AddAsync(Usuario entity);
        Task<Usuario> UpdateAsync(Usuario entity);
        Task<bool> DeleteAsync(string id);
    }
}

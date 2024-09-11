using GrApi.Data;
using GrApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GrApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext _context;
        private readonly UserManager<Usuario> _userManager;

        public UsuarioRepository(UsuarioContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Usuario> AddAsync(Usuario entity)
        {
            _context.Usuarios.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                Usuario usuario =
                await _context.Usuarios.Where(x => x.Id == id)
                    .FirstOrDefaultAsync() ?? new Usuario();

                if (String.IsNullOrEmpty(id)) return false;
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<Usuario>> FindAllAsync()
        {
            List<Usuario> usuarios = await _context.Usuarios.Include(u => u.Endereco).ToListAsync();
            return usuarios;
        } 
        public async Task<bool> FindUserAsync(string email, string password)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.UserName.ToLower() == email.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, password);

            return isValid ? true : false;
        }

        public async Task<Usuario> FindByIdAsync(string id)
        {
            Usuario customer =
                await _context.Usuarios.Where(x => x.Id == id).Include(x => x.Endereco)
                .FirstOrDefaultAsync() ?? new Usuario();
            return customer;
        }

        public async Task<Usuario> UpdateAsync(Usuario entity)
        {
            _context.Usuarios.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}

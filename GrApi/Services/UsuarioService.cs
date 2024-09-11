using AutoMapper;
using GrApi.Data;
using GrApi.DTO;
using GrApi.Models;
using GrApi.Repository;
using Microsoft.AspNetCore.Identity;

namespace GrApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UsuarioContext _usuarioContext;
        private readonly UserManager<Usuario> _userManager;
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;


        public UsuarioService(UsuarioContext userContext, UserManager<Usuario> userManager, IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _usuarioContext = userContext;
            _userManager = userManager;
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioDTO> Register(UsuarioDTO request)
        {
            Usuario user = _mapper.Map<Usuario>(request);
            user.NormalizedEmail = request.Email.ToUpper();
            user.UserName = request.Email;

            try
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _usuarioContext.Usuarios.First(u => u.UserName == request.Email);

                    UsuarioDTO userDTO = _mapper.Map<UsuarioDTO>(userToReturn);

                    return userDTO;
                }
                else { return null; }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuarioDTO> Update(UsuarioDTO request)
        {
            Usuario user = _mapper.Map<Usuario>(request);
            try
            {
                return _mapper.Map<UsuarioDTO>(_usuarioRepository.UpdateAsync(user));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<IEnumerable<UsuarioDTO>> ListarTodos()
        {
            return _mapper.Map<IEnumerable<UsuarioDTO>>(await _usuarioRepository.FindAllAsync());
        }
        public async Task<UsuarioDTO> ListarID(string id)
        {
            return _mapper.Map<UsuarioDTO>(await _usuarioRepository.FindByIdAsync(id));
        }

        public async Task<bool> Login(UsuarioLoginDTO request)
        {
            try
            {
                bool result = await _usuarioRepository.FindUserAsync(request.Email, request.Password);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

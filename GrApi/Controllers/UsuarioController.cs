using GrApi.DTO;
using GrApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GrApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Register([FromBody] UsuarioDTO model)
        {
            try
            {
                var result = await _usuarioService.Register(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("atualizar")]
        public async Task<IActionResult> Update([FromBody] UsuarioDTO model)
        {
            try
            {
                var result = await _usuarioService.Update(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDTO model)
        {
            try
            {
                var result = await _usuarioService.Login(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> FindAllAsync()
        {
            try
            {
                var usuarios = await _usuarioService.ListarTodos();
                return Ok(usuarios); ;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("listar/{id}")]
        public async Task<ActionResult<UsuarioDTO>> FindByIdAsync(string id)
        {
            try
            {
                var usuarios = await _usuarioService.ListarID(id);
                return Ok(usuarios); ;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

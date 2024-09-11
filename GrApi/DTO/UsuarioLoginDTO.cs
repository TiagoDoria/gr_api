using System.ComponentModel.DataAnnotations;

namespace GrApi.DTO
{
    public class UsuarioLoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

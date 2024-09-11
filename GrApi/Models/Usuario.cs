using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GrApi.Models
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
    }
}

namespace GrApi.DTO
{
    public class UsuarioDTO
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public EnderecoDTO Endereco { get; set; }

    }
}

using AutoMapper;
using GrApi.DTO;
using GrApi.Models;

namespace GrApi.Data
{
    public class Mappings
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<UsuarioDTO, Usuario>().ReverseMap();
                config.CreateMap<EnderecoDTO, Endereco>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}

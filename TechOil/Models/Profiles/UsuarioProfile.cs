using AutoMapper;
using System.Runtime;
using TechOil.Models.DTOs;

namespace TechOil.Models.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile() 
        {
            CreateMap<Usuario, UsuarioDTO>();
        }
    }
}

using AutoMapper;
using TechOil.Models.DTOs;

namespace TechOil.Models.Profiles
{
    public class TrabajoProfile : Profile
    {
        public TrabajoProfile() 
        {
            CreateMap<Trabajo, TrabajoDTO>();
        }
    }
}

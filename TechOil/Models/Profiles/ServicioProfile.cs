using AutoMapper;
using TechOil.Models.DTOs;

namespace TechOil.Models.Profiles
{
    public class ServicioProfile : Profile
    {
        public ServicioProfile() 
        {
            CreateMap<Servicio, ServicioDTO>();
        }
    }
}

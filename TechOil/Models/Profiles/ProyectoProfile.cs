using AutoMapper;
using TechOil.Models.DTOs;

namespace TechOil.Models.Profiles
{
    public class ProyectoProfile : Profile
    {
        public ProyectoProfile() {
            CreateMap<Proyecto, ProyectoDTO>();
        }
    }
}

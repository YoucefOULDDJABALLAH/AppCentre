using AppCentre.API.DTOs.InComing;
using AppCentre.API.Models;
using AutoMapper;

namespace AppCentre.API.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterationModelDTO, ApplicationUser>()
                .ForMember(dest => dest.Email, src => src.MapFrom(src => $"{src.UserName}@AppCentre.com"))
                .ForMember(dest => dest.EmailConfirmed, src => src.MapFrom(src => true)); ;
        }
    }
}

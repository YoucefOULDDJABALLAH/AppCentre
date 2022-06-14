using AppCentre.API.DTOs.InComing;
using AppCentre.API.DTOs.OutGoing;
using AppCentre.API.Models;
using AutoMapper;

namespace AppCentre.API.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterationModelDTO, ApplicationUser>()
                .ForMember(dest => dest.Email, src => src.MapFrom(src => $"{src.UserName}@AppCentre.DRH"))
                .ForMember(dest => dest.EmailConfirmed, src => src.MapFrom(src => true));

            CreateMap<ApplicationRole, CreatedRoleModelDTO>()
                .ForMember(dest => dest.RoleName, src => src.MapFrom(src => src.Name))
                .ForMember(dest => dest.ApplicationID, src => src.MapFrom(src => src.ApplicationsID))
                .ForMember(dest => dest.RoleId, src => src.MapFrom(src => src.Id))
                .ForMember(dest => dest.ApplicationName, src => src.MapFrom(src => src.App.ApplicationsName));
        }
    }
}

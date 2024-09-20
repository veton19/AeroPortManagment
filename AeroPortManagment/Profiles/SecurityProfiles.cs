using AeroPortManagment.DTOs;
using AeroPortManagment.HelperDto;
using AeroPortManagment.Models;
using AutoMapper;

namespace AeroPortManagment.Profiles
{
    public class SecurityProfiles : Profile
    {
        public SecurityProfiles()
        {
            CreateMap<Security, SecurityDTO>()
                .ForMember(dest => dest.FlightId, opt => opt.MapFrom(src => src.FlightId));
            CreateMap<Security, SecurityDTO>()
                .ForMember(dest => dest.PassengerId, opt => opt.MapFrom(src => src.PassengerId));
            CreateMap<CreateSecurity,Security>()
                .ForMember(dest=>dest.SecurityId,opt=>opt.MapFrom(src=>Guid.NewGuid()));
            CreateMap<UpdateSecurity, Security>();
        }
    }
}

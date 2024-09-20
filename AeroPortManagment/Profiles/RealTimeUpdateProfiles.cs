using AeroPortManagment.DTOs;
using AeroPortManagment.HelperDto;
using AeroPortManagment.Models;
using AutoMapper;
using System.Runtime;

namespace AeroPortManagment.Profiles
{
    public class RealTimeUpdateProfiles : Profile
    {
        public RealTimeUpdateProfiles()
        {
            CreateMap<RealTimeUpdate, RealTimeUpdateDTO>()
                .ForMember(dest => dest.FlightId, opt => opt.MapFrom(src => src.FlightId));

            CreateMap<CreateRealTimeUpdate, RealTimeUpdate>()
                .ForMember(dest => dest.UpdateId, opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<UpdateRealTimeUpdate, RealTimeUpdate>();
        }       
    }
}

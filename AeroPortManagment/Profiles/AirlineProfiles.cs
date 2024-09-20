using AeroPortManagment.DTOs;
using AeroPortManagment.HelperDto;
using AeroPortManagment.Models;
using AutoMapper;

namespace AeroPortManagment.Profiles
{
    public class AirlineProfiles : Profile
    {
        public AirlineProfiles() 
        {
            CreateMap<Airline,AirlineDTO>()
                .ForMember(des=>des.Flights,opt=>opt.MapFrom(src=>src.Flights));
            CreateMap<CreateAirlineDTO,Airline>()
                .ForMember(des=>des.AirlineId,opt=>opt.MapFrom(src=>Guid.NewGuid()));
            CreateMap<UpdateAirlineDTO, Airline>();
        }
    }
}

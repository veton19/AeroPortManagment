using AeroPortManagment.DTOs;
using AeroPortManagment.HelperDto;
using AeroPortManagment.Models;
using AutoMapper;

namespace AeroPortManagment.Profiles
{
    public class AirportProfiles : Profile
    {
        public AirportProfiles()
        {
            CreateMap<Airport,AirportDTO>()
                .ForMember(dest=>dest.Flights,opt=>opt.MapFrom(src => src.Flights));

            CreateMap<Airport,AirportDTO>()
                .ForMember(dest=>dest.Employees,opt=>opt.MapFrom(src => src.Employees));
            CreateMap<CreateAirportDTO,Airport>()
                .ForMember(dest=>dest.AirportId,opt=>opt.MapFrom(src=>Guid.NewGuid()));
            CreateMap<UpdateAirportDTO, Airport>();
        }
    }
}

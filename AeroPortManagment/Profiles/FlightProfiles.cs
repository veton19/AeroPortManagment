using AeroPortManagment.DTOs;
using AeroPortManagment.HelperDto;
using AeroPortManagment.Models;
using AutoMapper;

namespace AeroPortManagment.Profiles
{
    public class FlightProfiles : Profile
    {
        public FlightProfiles()
        {
            CreateMap<Flight, FlightDTO>()
                .ForMember(dest => dest.ResourceAllocations, opt => opt.MapFrom(src => src.ResourceAllocations));
            CreateMap<Flight, FlightDTO>()
                .ForMember(dest => dest.Passengers, opt => opt.MapFrom(src => src.Passengers));
            CreateMap<Flight, FlightDTO>()
                .ForMember(dest=>dest.Bookings,opt=>opt.MapFrom(src=>src.Bookings));
            CreateMap<CreateFlightDTO, Flight>()
                .ForMember(dest=>dest.Id,opt=>opt.MapFrom(src=>Guid.NewGuid()));
            CreateMap<UpdateFlightDTO, Flight>();
        }
    }
}

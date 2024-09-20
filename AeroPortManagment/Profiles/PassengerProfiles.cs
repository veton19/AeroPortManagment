using AeroPortManagment.DTOs;
using AeroPortManagment.HelperDto;
using AeroPortManagment.Models;
using AutoMapper;

namespace AeroPortManagment.Profiles
{
    public class PassengerProfiles : Profile
    {
        public PassengerProfiles()
        {
            CreateMap<Passenger, PassengerDTO>()
                .ForMember(dest => dest.Bookings, opt => opt.MapFrom(src => src.Bookings));
            CreateMap<CreatePassengerDTO, Passenger>()
                .ForMember(dest=>dest.PassengerId,opt=>opt.MapFrom(src=>Guid.NewGuid()));
            CreateMap<UpdatePassengerDTO, Passenger>();
        }
        
    }
}

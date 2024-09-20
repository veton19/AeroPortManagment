using AeroPortManagment.DTOs;
using AeroPortManagment.HelperDto;
using AeroPortManagment.Models;
using AutoMapper;

namespace AeroPortManagment.Profiles
{
    public class BookingProfiles : Profile
    {
        public BookingProfiles() 
        {
            CreateMap<Booking, BookingDTO>()
                .ForMember(dest => dest.FlightId, opt => opt.MapFrom(src => src.FlightId));
            CreateMap<Booking,BookingDTO>()
                .ForMember(dest=>dest.PassengerId,opt=>opt.MapFrom(src=>src.PassengerId));
            CreateMap<CreateBookingDTO,Booking>()
                .ForMember(dest=>dest.BookingId,opt=>opt.MapFrom(src=>Guid.NewGuid()));
            CreateMap<UpdateBookingDTO, Booking>();
        }
    }
}

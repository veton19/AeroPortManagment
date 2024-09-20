using AeroPortManagment.DTOs;
using AeroPortManagment.HelperDto;
using AeroPortManagment.Models;
using AutoMapper;

namespace AeroPortManagment.Profiles
{
    public class CommercialActivityProfiles : Profile
    {
        public CommercialActivityProfiles()
        {
            CreateMap<CommercialActivity, CommercialActivityDTO>()
                .ForMember(dest => dest.FlightId, opt => opt.MapFrom(src => src.FlightId));
            CreateMap<CommercialActivity, CommercialActivityDTO>()
                .ForMember(dest => dest.PassengerId, opt => opt.MapFrom(src => src.PassengerId));
            CreateMap<CreateCommercialActivityDTO,CommercialActivity>()
                .ForMember(dest=>dest.ActivityId,opt=>opt.MapFrom(src=>Guid.NewGuid()));
            CreateMap<UpdateCommercialActivityDTO, CommercialActivity>();
        }
    }
}

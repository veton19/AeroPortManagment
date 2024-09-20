using AeroPortManagment.DTOs;
using AeroPortManagment.HelperDto;
using AeroPortManagment.Models;
using AutoMapper;

namespace AeroPortManagment.Profiles
{
    public class ResourceAllocationProfiles : Profile
    {
        public ResourceAllocationProfiles()
        {
            CreateMap<ResourceAllocation, ResourceAllocationDTO>()
                .ForMember(dest => dest.FlightId, opt => opt.MapFrom(src => src.FlightId));

            CreateMap<CreateResourceAllocation, ResourceAllocation>()
                .ForMember(dest => dest.ResourceId, opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<UpdateResourceAllocation, ResourceAllocation>();
        }
    }
}

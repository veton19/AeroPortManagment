using AeroPortManagment.DTOs;
using AeroPortManagment.HelperDto;
using AeroPortManagment.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AeroPortManagment.Profiles
{
    public class EmployeeProfiles : Profile
    {
        public EmployeeProfiles()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<CreateEmployeeDTO, Employee>()
                .ForMember(dest=>dest.EmployeeId,opt=>opt.MapFrom(src=>Guid.NewGuid()));
            CreateMap<UpdateEmployeeDTO, Employee>();
        }
    }
}

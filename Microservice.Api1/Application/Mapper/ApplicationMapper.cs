using AutoMapper;
using Microservice.Api2.Core.Models.Entities;
using Microservice.Api2.Application.Commands;
using Microservice.Api2.Application.Responses;
using Microservice.Api2.Core.Models.ServiceBus;

namespace Microservice.Api2.Application.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMapping();
        }
        
        private void CreateMapping()
        {

            CreateMap<CreateEmployeeComannd , Employee>()
                .ForMember(dest => dest.EmployeeId, map => map.Ignore())
                .ForMember(dest => dest.EmployeeNumber, map => map.MapFrom(src => src.EmployeeNumber))
                .ForMember(dest => dest.Title, map => map.MapFrom(src => src.Title))
                .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, map => map.MapFrom(src => src.LastName))
                .ForMember(dest => dest.BirthDate, map => map.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.HireDate, map => map.MapFrom(src => src.HireDate))
                .ForMember(dest => dest.Salary, map => map.MapFrom(src => src.Salary))
                .ForMember(dest => dest.Designation, map => map.MapFrom(src => src.Designation))
                .ForMember(dest => dest.Department, map => map.MapFrom(src => src.Department)).ReverseMap();

            CreateMap<Employee, EmployeeResponse>()
                .ForMember(dest => dest.EmployeeId, map => map.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.EmployeeNumber, map => map.MapFrom(src => src.EmployeeNumber))
                .ForMember(dest => dest.Title, map => map.MapFrom(src => src.Title))
                .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, map => map.MapFrom(src => src.LastName))
                .ForMember(dest => dest.BirthDate, map => map.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.HireDate, map => map.MapFrom(src => src.HireDate))
                .ForMember(dest => dest.Salary, map => map.MapFrom(src => src.Salary))
                .ForMember(dest => dest.Designation, map => map.MapFrom(src => src.Designation))
                .ForMember(dest => dest.Department, map => map.MapFrom(src => src.Department)).ReverseMap();

            CreateMap<Employee, EmployeePayload>()
                .ForMember(dest => dest.EmployeeNumber, map => map.MapFrom(src => src.EmployeeNumber))
                .ForMember(dest => dest.Title, map => map.MapFrom(src => src.Title))
                .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, map => map.MapFrom(src => src.LastName))
                .ForMember(dest => dest.BirthDate, map => map.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.HireDate, map => map.MapFrom(src => src.HireDate))
                .ForMember(dest => dest.Salary, map => map.MapFrom(src => src.Salary))
                .ForMember(dest => dest.Designation, map => map.MapFrom(src => src.Designation))
                .ForMember(dest => dest.Department, map => map.MapFrom(src => src.Department)).ReverseMap();
        }
    }
}

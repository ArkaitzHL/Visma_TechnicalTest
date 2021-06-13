using AutoMapper;
using Visma_TechnicalTest.Api.Resources;
using Visma_TechnicalTest.Core.Models;

namespace Visma_TechnicalTest.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeResource>();

            CreateMap<EmployeeResource, Employee>();
            CreateMap<SaveEmployeeResource, Employee>();
        }
    }
}

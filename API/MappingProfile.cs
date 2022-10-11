using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AuditPlan, AuditPlanDto>();
    }
}
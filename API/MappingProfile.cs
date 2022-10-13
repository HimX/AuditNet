using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AuditPlan, AuditPlanDto>();
        CreateMap<AuditPlanForCreationDto, AuditPlan>();
        CreateMap<AuditPlanForUpdateDto, AuditPlan>();

        CreateMap<Audit, AuditDto>();
        CreateMap<AuditForCreationDto, Audit>();
        CreateMap<AuditForUpdateDto, Audit>().ReverseMap();
    }
}
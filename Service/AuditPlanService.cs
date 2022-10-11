using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

internal sealed class AuditPlanService : IAuditPlanService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public AuditPlanService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public IEnumerable<AuditPlanDto> GetAllAuditPlans(bool trackChanges)
    {
        var auditPlans = _repository.AuditPlan.GetAllAuditPlans(trackChanges);
        var auditPlansDto = _mapper.Map<IEnumerable<AuditPlanDto>>(auditPlans);
        return auditPlansDto;
    }

    public AuditPlanDto GetAuditPlan(Guid auditPlanId, bool trackChanges)
    {
        var auditPlan = _repository.AuditPlan.GetAuditPlan(auditPlanId, trackChanges);

        if (auditPlan is null)
            throw new AuditPlanNotFoundException(auditPlanId);

        var auditPlanDto = _mapper.Map<AuditPlanDto>(auditPlan);
        return auditPlanDto;
    }
}
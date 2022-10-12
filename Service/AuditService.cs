using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public class AuditService : IAuditService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public AuditService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public IEnumerable<AuditDto> GetAudits(Guid auditPlanId, bool trackChanges)
    {
        var auditPlan = _repository.AuditPlan.GetAuditPlan(auditPlanId, trackChanges);
        if (auditPlan is null)
            throw new AuditPlanNotFoundException(auditPlanId);
        var audits = _repository.Audit.GetAudits(auditPlanId, trackChanges);
        var auditsDto = _mapper.Map<IEnumerable<AuditDto>>(audits);

        return auditsDto;
    }

    public AuditDto GetAudit(Guid auditPlanId, Guid id, bool trackChanges)
    {
        var plan = _repository.AuditPlan.GetAuditPlan(auditPlanId, trackChanges);
        if (plan is null)
            throw new AuditPlanNotFoundException(auditPlanId);

        var auditDb = _repository.Audit.GetAudit(auditPlanId, id, trackChanges);
        if (auditDb is null)
            throw new AuditNotFoundException(id);

        var audit = _mapper.Map<AuditDto>(auditDb);
        return audit;
    }

    public AuditDto CreateAuditForPlan(Guid auditPlanId, AuditForCreationDto auditForCreationDto, bool trackChanges)
    {
        var plan = _repository.AuditPlan.GetAuditPlan(auditPlanId, trackChanges);
        if (plan is null)
            throw new AuditPlanNotFoundException(auditPlanId);

        var auditEntity = _mapper.Map<Audit>(auditForCreationDto);
        _repository.Audit.CreateAuditForPlan(auditPlanId, auditEntity);
        _repository.Save();
        var auditToReturn = _mapper.Map<AuditDto>(auditEntity);
        
        return auditToReturn;
    }
}
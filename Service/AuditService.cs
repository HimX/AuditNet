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

    public void DeleteAuditForPlan(Guid auditPlanId, Guid id, bool trackChanges)
    {
        var plan = _repository.AuditPlan.GetAuditPlan(auditPlanId, trackChanges);

        if (plan is null)
            throw new AuditPlanNotFoundException(auditPlanId);

        var auditForPlan = _repository.Audit.GetAudit(auditPlanId, id, trackChanges);

        if (auditForPlan is null)
            throw new AuditNotFoundException(id);

        _repository.Audit.DeleteAudit(auditForPlan);
        _repository.Save();
    }

    public void UpdateAuditForPlan(Guid auditPlanId, Guid id, AuditForUpdateDto auditForUpdateDto,
        bool planTrackChanges,
        bool auditTrackChanges)
    {
        var plan = _repository.AuditPlan.GetAuditPlan(auditPlanId, planTrackChanges);

        if (plan is null)
            throw new AuditPlanNotFoundException(auditPlanId);

        var auditEntity = _repository.Audit.GetAudit(auditPlanId, id, auditTrackChanges);

        if (auditEntity is null)
            throw new AuditNotFoundException(id);

        _mapper.Map(auditForUpdateDto, auditEntity);
        _repository.Save();
    }

    public (AuditForUpdateDto auditToPatch, Audit auditEntity) GetAuditForPatch(Guid auditPlanId, Guid id,
        bool planTrackChanges,
        bool auditTrackChanges)
    {
        var plan = _repository.AuditPlan.GetAuditPlan(auditPlanId, planTrackChanges);
        if (plan is null)
            throw new AuditPlanNotFoundException(auditPlanId);

        var auditEntity = _repository.Audit.GetAudit(auditPlanId, id, auditTrackChanges);
        if (auditEntity is null)
            throw new AuditNotFoundException(id);

        var auditToPatch = _mapper.Map<AuditForUpdateDto>(auditEntity);

        return (auditToPatch, auditEntity);
    }

    public void SaveChangesForPatch(AuditForUpdateDto auditToPatch, Audit auditEntity)
    {
        _mapper.Map(auditToPatch, auditEntity);
        _repository.Save();
    }
}
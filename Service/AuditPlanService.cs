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

    public AuditPlanDto CreateAuditPlan(AuditPlanForCreationDto auditPlan)
    {
        var auditPlanEntity = _mapper.Map<AuditPlan>(auditPlan);
        _repository.AuditPlan.CreateAuditPlan(auditPlanEntity);
        _repository.Save();
        var auditPlanToReturn = _mapper.Map<AuditPlanDto>(auditPlanEntity);

        return auditPlanToReturn;
    }

    public IEnumerable<AuditPlanDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var planEntities = _repository.AuditPlan.GetByIds(ids, trackChanges);

        if (ids.Count() != planEntities.Count())
            throw new CollectionByIdsBadRequestException();

        var plansToReturn = _mapper.Map<IEnumerable<AuditPlanDto>>(planEntities);

        return plansToReturn;
    }

    public (IEnumerable<AuditPlanDto> plans, string ids) CreateAuditPlanCollection
        (IEnumerable<AuditPlanForCreationDto> auditPlanCollection)
    {
        if (auditPlanCollection is null)
            throw new AuditPlanCollectionBadRequest();

        var planEntities = _mapper.Map<IEnumerable<AuditPlan>>(auditPlanCollection);

        foreach (var plan in planEntities)
        {
            _repository.AuditPlan.CreateAuditPlan(plan);
        }

        _repository.Save();
        var planCollectionToReturn = _mapper.Map<IEnumerable<AuditPlanDto>>(planEntities);
        var ids = string.Join(",", planCollectionToReturn.Select(p => p.Id));

        return (plans: planCollectionToReturn, ids: ids);
    }
}
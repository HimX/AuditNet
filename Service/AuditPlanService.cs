using AutoMapper;
using Contracts;
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
        try
        {
            var auditPlans = _repository.AuditPlan.GetAllAuditPlans(trackChanges);
            var auditPlansDto = _mapper.Map<IEnumerable<AuditPlanDto>>(auditPlans);
            return auditPlansDto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
using AutoMapper;
using Contracts;
using Service.Contracts;

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
}
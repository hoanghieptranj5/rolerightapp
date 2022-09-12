using RoleRightApp.Logics.Abstractions;
using RoleRightApp.Repositories.Abstractions;
using RoleRightApp.Repositories.Models;

namespace RoleRightApp.Logics.Implementations;

public class RequestLogic : IRequestLogic
{
    private readonly IRequestRepository _requestRepository;

    public RequestLogic(IRequestRepository requestRepository)
    {
        _requestRepository = requestRepository;
    }

    public async Task<List<RequestModel>> GetAllRequest()
    {
       return await _requestRepository.GetAllRequest();
    }
}

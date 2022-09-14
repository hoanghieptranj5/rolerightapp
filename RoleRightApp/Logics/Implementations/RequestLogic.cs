using AutoMapper;
using RoleRightApp.Logics.Abstractions;
using RoleRightApp.Repositories.Abstractions;
using RoleRightApp.Repositories.Models;
using RoleRightApp.RequestModels;

namespace RoleRightApp.Logics.Implementations;

public class RequestLogic : IRequestLogic
{
    private readonly IRequestRepository _requestRepository;
    private readonly IMapper _mapper;

    public RequestLogic(IRequestRepository requestRepository, IMapper mapper)
    {
        _requestRepository = requestRepository;
        _mapper = mapper;
    }

    public async Task<List<RequestModel>> GetAllRequest()
    {
       return await _requestRepository.GetAllRequest();
    }

    public async Task<string> CreateRequest(RequestRequestModel requestModel) {
        var request = _mapper.Map<RequestRequestModel, RequestModel>(requestModel);
        request.CreatedAt = new DateTime();
        request.RequestId = Guid.NewGuid().ToString();
        return await _requestRepository.CreateRequest(request);
    }
}

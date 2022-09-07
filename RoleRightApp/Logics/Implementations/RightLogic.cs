using AutoMapper;
using RoleRightApp.Logics.Abstractions;
using RoleRightApp.Repositories.Abstractions;
using RoleRightApp.Repositories.Models;
using RoleRightApp.RequestModels;

namespace RoleRightApp.Logics.Implementations;

public class RightLogic : IRightLogic
{
    private readonly IRightRepository _rightRepository;
    private readonly IMapper _mapper;

    public RightLogic(IRightRepository rightRepository, IMapper mapper)
    {
        _rightRepository = rightRepository;
        _mapper = mapper;
    }

    public async Task<string> UpdateRight(RightModel right)
    {
        
        var result = await _rightRepository.UpdateRight(right);

        return result;
    }
}

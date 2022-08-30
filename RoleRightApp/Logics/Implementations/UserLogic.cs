using AutoMapper;
using RoleRightApp.Logics.Abstractions;
using RoleRightApp.Logics.Helpers;
using RoleRightApp.Repositories.Abstractions;
using RoleRightApp.Repositories.Models;
using RoleRightApp.RequestModels;

namespace RoleRightApp.Logics.Implementations;

public class UserLogic : IUserLogic
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserLogic(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserModel> GetUser(string userId)
    {
        return await _userRepository.GetUser(userId);
    }

    public async Task<string> SaveUser(RegisterRequestModel userModel)
    {
        var mapped = _mapper.Map<RegisterRequestModel, UserModel>(userModel);

        mapped.UserId = Guid.NewGuid().ToString();
        mapped.CreatedAt = DateTime.Now;
        mapped.Password = EncodingHelper.EncodePasswordToBase64(userModel.Password);
        
        var userId = await _userRepository.SaveUser(mapped);
        
        return userId;
    }

    public async Task<IEnumerable<UserModel>> GetAllUsers()
    {
        return await _userRepository.GetAllUsers();
    }
}
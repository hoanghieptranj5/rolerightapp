using RoleRightApp.Repositories.Models;
using RoleRightApp.RequestModels;

namespace RoleRightApp.Logics.Abstractions;

public interface IUserLogic
{
    Task<UserModel> GetUser(string userId);
    Task<string> SaveUser(RegisterRequestModel requestModel);
    Task<IEnumerable<UserModel>> GetAllUsers();
}
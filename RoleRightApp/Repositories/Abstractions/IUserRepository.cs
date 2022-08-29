using RoleRightApp.Repositories.Models;

namespace RoleRightApp.Repositories.Abstractions;

public interface IUserRepository
{
    Task<UserModel> GetUser(string userId);
    Task<List<UserModel>> GetAllUsers();
    Task<string> SaveUser(UserModel userModel);
    Task<string> DeleteUser(string userId);
}
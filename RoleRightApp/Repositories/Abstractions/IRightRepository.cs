using RoleRightApp.Repositories.Models;

namespace RoleRightApp.Repositories.Abstractions;

public interface IRightRepository
{
    Task<List<RightModel>> GetAllRights();
    Task<RightModel> GetRight(string rightId);
    Task<string> SaveRight(RightModel rightModel);
    Task<string> UpdateRight(RightModel rightModel);
}

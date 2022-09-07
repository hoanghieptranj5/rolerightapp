using RoleRightApp.Repositories.Models;
using RoleRightApp.RequestModels;

namespace RoleRightApp.Logics.Abstractions
{
    public interface IRightLogic
    {
        Task<List<RightModel>> GetAllRight();
        Task<RightModel> GetRight(string rightId);
        Task<string> SaveRight(RightRequestModel rightModel);

    }
}

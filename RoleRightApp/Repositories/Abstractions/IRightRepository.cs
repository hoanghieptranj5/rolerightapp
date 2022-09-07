using RoleRightApp.Repositories.Models;

namespace RoleRightApp.Repositories.Abstractions;

public interface IRightRepository
{
    Task<string> UpdateRight(RightModel rightModel);
}

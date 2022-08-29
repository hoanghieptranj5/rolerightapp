using RoleRightApp.Repositories.Models;

namespace RoleRightApp.Repositories.Abstractions;

public interface IRoleRepository
{
    Task<List<RoleModel>> GetAllRoles();
}
using RoleRightApp.Repositories.Models;

namespace RoleRightApp.Logics.Abstractions;

public interface IRequestLogic
{
    Task<List<RequestModel>> GetAllRequest();

}

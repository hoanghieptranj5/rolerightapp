using RoleRightApp.Repositories.Models;

namespace RoleRightApp.Repositories.Abstractions;

public interface IRequestRepository
{
    Task<List<RequestModel>> GetAllRequest();
    Task<string> CreateRequest(RequestModel requestModel);
}

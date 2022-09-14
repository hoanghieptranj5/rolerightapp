using RoleRightApp.Repositories.Models;
using RoleRightApp.RequestModels;

namespace RoleRightApp.Logics.Abstractions;

public interface IRequestLogic
{
    Task<List<RequestModel>> GetAllRequest();
    Task<string> CreateRequest(RequestRequestModel requestRequestModel);
}

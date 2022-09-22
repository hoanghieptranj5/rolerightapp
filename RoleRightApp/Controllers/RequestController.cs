using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoleRightApp.Constants;
using RoleRightApp.Logics.Abstractions;
using RoleRightApp.Repositories.Models;
using RoleRightApp.RequestModels;

namespace RoleRightApp.Controllers;
[Authorize]
[Route("api/[controller]")]
public class RequestController : ControllerBase
{
    private readonly IRequestLogic _requestLogic;

    public RequestController(IRequestLogic requestLogic)
    {
        _requestLogic = requestLogic;
    }

    [HttpGet]
    public async Task<List<RequestModel>> GetAllRequest()
    {
        return await _requestLogic.GetAllRequest();
    }

    [Authorize(Roles = Roles.Employee)]
    [HttpPost]
    public async Task<string> CreateRequest([FromBody] RequestRequestModel requestRequestModel) 
    {
        return await _requestLogic.CreateRequest(requestRequestModel);
    }
}

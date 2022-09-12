using Microsoft.AspNetCore.Mvc;
using RoleRightApp.Logics.Abstractions;
using RoleRightApp.Repositories.Models;

namespace RoleRightApp.Controllers;

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
}

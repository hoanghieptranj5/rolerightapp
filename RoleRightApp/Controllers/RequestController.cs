using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoleRightApp.Constants;
using RoleRightApp.Logics.Abstractions;
using RoleRightApp.Repositories.Models;
using RoleRightApp.RequestModels;

namespace RoleRightApp.Controllers;
[Route("api/[controller]")]
public class RequestController : ControllerBase
{
    private readonly IRequestLogic _requestLogic;

    public RequestController(IRequestLogic requestLogic)
    {
        _requestLogic = requestLogic;
    }

    [Authorize]
    [HttpGet]
    public async Task<IEnumerable<RequestModel>> GetAllRequest()
    {
        return await _requestLogic.GetAllRequest();
    }

    [Authorize(Roles = Roles.Employee)]
    [HttpPost]
    public async Task<IActionResult> CreateRequest([FromBody] RequestRequestModel requestRequestModel) 
    {
        var createdId = await _requestLogic.CreateRequest(requestRequestModel);
        return Created(string.Empty, createdId);
    }
}

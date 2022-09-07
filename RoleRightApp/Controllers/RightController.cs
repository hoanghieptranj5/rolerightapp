using Microsoft.AspNetCore.Mvc;
using RoleRightApp.Logics.Abstractions;
using RoleRightApp.Repositories.Models;
using RoleRightApp.RequestModels;

namespace RoleRightApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RightController : ControllerBase
{
    private readonly IRightLogic _rightLogic;

    public RightController(IRightLogic rightLogic)
    {
        _rightLogic = rightLogic;
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRight(RightModel rightModel)
    {
        var right = await _rightLogic.UpdateRight(rightModel);
        return Ok(right);
    }
}

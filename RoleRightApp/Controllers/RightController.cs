using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoleRightApp.Logics.Abstractions;
using RoleRightApp.Repositories.Abstractions;
using RoleRightApp.Repositories.Models;

namespace RoleRightApp.Controllers;

[Authorize]
[Route("api/[controller]")]
public class RightController: ControllerBase
{
    private readonly IRightRepository _rightRepository;
    private readonly IRightLogic _rightLogic;

    public RightController(IRightRepository rightRepository, IRightLogic rightLogic)
    {
        _rightRepository = rightRepository;
        _rightLogic = rightLogic;
    }
    
    [HttpGet("get_all_rights")]
    public async Task<IActionResult> GetAllRights() 
    {
        var result = await _rightRepository.GetAllRights();
        Console.WriteLine(result);

        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateRight(RightModel rightModel)
    {
        var right = await _rightLogic.UpdateRight(rightModel);
        return Ok(right);
    }
}


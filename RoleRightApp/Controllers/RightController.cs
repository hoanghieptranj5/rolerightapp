using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoleRightApp.Logics.Abstractions;
using RoleRightApp.Repositories.Abstractions;
using RoleRightApp.Repositories.Models;
using RoleRightApp.RequestModels;

namespace RoleRightApp.Controllers;

[Route("api/[controller]")]
public class RightController : ControllerBase
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

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRight(string id, [FromBody] RightRequestModel request)
    {
        var right = await _rightLogic.UpdateRight(id, request);
        return Ok(right);
    }

    [HttpPost]
    public async Task<string> SaveRight(RightRequestModel rightRequestModel)
    {
        var res = await _rightLogic.SaveRight(rightRequestModel);
        return res;
    }
}


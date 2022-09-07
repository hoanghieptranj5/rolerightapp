using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoleRightApp.Repositories.Abstractions;

namespace RoleRightApp.Controllers;

[Authorize]
[Route("api/[controller]")]
public class RightController: ControllerBase
{
    private readonly IRightRepository _rightRepository;

    public RightController(IRightRepository rightRepository)
    {
        _rightRepository = rightRepository;
    }

    // GET api/values
    [HttpGet("get_all_rights")]
    public async Task<IActionResult> GetAllRights() 
    {
        var result = await _rightRepository.GetAllRights();
        Console.WriteLine(result);

        return Ok(result);
    }
}


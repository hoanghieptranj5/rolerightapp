using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using RoleRightApp.Constants;
using RoleRightApp.Repositories.Abstractions;

namespace RoleRightApp.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    private readonly IRoleRepository _roleRepository;
    private readonly ApplicationDbContext _dbContext;

    public ValuesController(ApplicationDbContext dbContext, IRoleRepository roleRepository)
    {
        _dbContext = dbContext;
        _roleRepository = roleRepository;
    }

    // GET api/values
    [Authorize(Roles = Roles.Employee)]
    [HttpGet("allRoles")]
    public async Task<IActionResult> GetAllRoles()
    {
        var result = await _roleRepository.GetAllRoles();
        
        return Ok(result);
    }
    
    // GET api/values
    [HttpGet]
    public IEnumerable<string> Get()
    {
        var books = _dbContext.Book.Select(x => x.Title).ToList();
        return books;
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody]string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
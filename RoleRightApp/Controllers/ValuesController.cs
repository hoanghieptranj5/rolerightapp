using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc;
using RoleRightApp.Repositories;

namespace RoleRightApp.Controllers;

[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    private readonly IDynamoDBContext _dbContext;

    public ValuesController(IDynamoDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    // GET api/values
    [HttpGet("haha")]
    public async Task<IActionResult> GetABC()
    {
        var result = await _dbContext
            .ScanAsync<Role>(Array.Empty<ScanCondition>())
            .GetRemainingAsync();
        
        return Ok(result);
    }
    
    // GET api/values
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
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
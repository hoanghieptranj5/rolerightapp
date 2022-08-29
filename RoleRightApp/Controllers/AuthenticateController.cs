using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RoleRightApp.Repositories.Abstractions;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace RoleRightApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticateController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public AuthenticateController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(string userName, string password)
    {
        var allUsers = await _userRepository.GetAllUsers();
        var existingUser = allUsers.FirstOrDefault(u => u.Username == userName && u.Password == password);

        if (existingUser == null)
        {
            throw new Exception("User doesn't exist!");
        }
        
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecretHereBuajsdlkaj;sdjlkajsdlk;ja;lsjd;lkasjdlkjaslkdj;lajs;lkdjal;ksjdl;kajs;lkdjalksjd;lkajd"));

        var token = new JwtSecurityToken(
            issuer: "haha", 
            audience: "audience",
            expires: DateTime.Now.AddHours(1),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256));

        return Ok(new
        {
            token = "bearer " + new JwtSecurityTokenHandler().WriteToken(token),
            expiration = token.ValidTo
        });
    }
}
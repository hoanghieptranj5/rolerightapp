using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RoleRightApp.Constants;
using RoleRightApp.Logics.Abstractions;
using RoleRightApp.Logics.Helpers;
using RoleRightApp.Repositories.Models;
using RoleRightApp.RequestModels;
using RoleRightApp.Services.Abstractions;
using RoleRightApp.Services.Implementations;
using RoleRightApp.Services.Models;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace RoleRightApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticateController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IUserLogic _userLogic;
    private readonly IStorageService _storeService;

    public AuthenticateController(IConfiguration configuration, IUserLogic userLogic, IStorageService storeService)
    {
        _configuration = configuration;
        _userLogic = userLogic;
        _storeService = storeService;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(string userName, string password)
    {
        var decodedPassword = EncodingHelper.EncodePasswordToBase64(password);
        var allUsers = await _userLogic.GetAllUsers();

        var existingUser = allUsers.FirstOrDefault(u => 
            u.Username == userName && 
            u.Password == decodedPassword);

        if (existingUser == null)
        {
            throw new Exception("User doesn't exist!");
        }

        var authClaims = new List<Claim>
        {
            new(ClaimTypes.Name, userName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(ClaimTypes.Role, existingUser.Role == null ? "Employee" : existingUser.Role)
        };

        var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],  
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(1),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256));

        return Ok(new
        {
            token = "Bearer " + new JwtSecurityTokenHandler().WriteToken(token),
            expiration = token.ValidTo
        });
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromForm] RegisterRequestModel requestModel)
    {
        var objUpload = new S3ObjectUpload(requestModel.File!, "shane-dotnet-lambda-deploy", "file-excel");

        var responseUploadFile = await _storeService.UploadFileAsync(objUpload);

        var registered = await _userLogic.SaveUser(requestModel);
        return Ok(registered + "&" +responseUploadFile);
    }
}
using System.ComponentModel.DataAnnotations;

namespace RoleRightApp.RequestModels;

public class RegisterRequestModel
{
    public bool ForcePasswordChange { get; set; }
    
    public char UserType { get; set; }
    
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Password { get; set; }

    public string? Role { get; set; } = "Employee";
}
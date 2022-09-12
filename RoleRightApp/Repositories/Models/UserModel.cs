using Amazon.DynamoDBv2.DataModel;

namespace RoleRightApp.Repositories.Models;

[DynamoDBTable("user")]
public class UserModel
{
    [DynamoDBHashKey("userId")]
    public string UserId { get; set; }
    
    [DynamoDBProperty("createdAt")]
    public DateTime CreatedAt { get; set; }
    
    [DynamoDBProperty("forcePasswordChange")]
    public bool ForcePasswordChange { get; set; }
    
    [DynamoDBProperty("userType")]
    public char UserType { get; set; }
    
    [DynamoDBProperty("username")]
    public string Username { get; set; }
    
    [DynamoDBProperty("password")]
    public string Password { get; set; }
    [DynamoDBProperty("role")]
    public string Role { get; set; }
}
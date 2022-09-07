using Amazon.DynamoDBv2.DataModel;

namespace RoleRightApp.Repositories.Models;

[DynamoDBTable("right")]
public class RightModel
{
    [DynamoDBHashKey("rightId")]
    public string RightId { get; set; }

    [DynamoDBProperty("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [DynamoDBProperty("description")]
    public string Description { get; set; }    
}

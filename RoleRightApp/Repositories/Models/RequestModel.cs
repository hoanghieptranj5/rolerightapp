using Amazon.DynamoDBv2.DataModel;
using RoleRightApp.Constants;
namespace RoleRightApp.Repositories.Models;

[DynamoDBTable("requests")]
public class RequestModel
{
    [DynamoDBHashKey("requestId")]
    public string? RequestId { get; set; }

    [DynamoDBProperty("employeeId")]
    public string? EmployeeId { get; set; }

    [DynamoDBProperty("approveBy")]
    public string? ApproveBy { get; set; } = string.Empty;

    [DynamoDBProperty("status")]
    public string? Status { get; set; } = AbsenceStatus.Pending;

    [DynamoDBProperty("createdAt")]
    public DateTime CreatedAt { get; set; }

    [DynamoDBProperty("description")]
    public string? Description { get; set; }

    [DynamoDBProperty("startDate")]
    public DateTime StartDate { get; set; }

    [DynamoDBProperty("endDate")]
    public DateTime EndDate { get; set; }

}

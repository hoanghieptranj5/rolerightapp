using Amazon.DynamoDBv2.DataModel;
using RoleRightApp.Repositories.Abstractions;
using RoleRightApp.Repositories.Models;

namespace RoleRightApp.Repositories.Implementations;

public class RequestRepository : HashKeyOnlyRepositoryBase<RequestModel, string>, IRequestRepository
{
    public RequestRepository(IDynamoDBContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<RequestModel>> GetAllRequest()
    {
        return await GetList();
    }
}

using Amazon.DynamoDBv2.DataModel;
using RoleRightApp.Repositories.Abstractions;
using RoleRightApp.Repositories.Models;

namespace RoleRightApp.Repositories.Implementations;

public class RightRepository : HashKeyOnlyRepositoryBase<RightModel, string>, IRightRepository
{
    public RightRepository(IDynamoDBContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<RightModel>> GetAllRights()
    {
        return await GetList();
    }
}

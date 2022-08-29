using Amazon.DynamoDBv2.DataModel;
using RoleRightApp.Repositories.Abstractions;
using RoleRightApp.Repositories.Models;

namespace RoleRightApp.Repositories.Implementations;

public class RoleRepository : HashKeyOnlyRepositoryBase<RoleModel, string>, IRoleRepository
{
    public RoleRepository(IDynamoDBContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<RoleModel>> GetAllRoles()
    {
        return await GetList();
    }
}
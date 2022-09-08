using Amazon.DynamoDBv2.DataModel;
using RoleRightApp.Repositories.Abstractions;
using RoleRightApp.Repositories.Models;
using RoleRightApp.RequestModels;

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

    public async Task<string> UpdateRight(RightModel rightmodel)
    {
        var right = await GetByHashKey(rightmodel.RightId);
        if (right == null) return "Right does not exist";
        else
        {
            await SaveAsync(rightmodel);
            return rightmodel.RightId;
        }
    }
    public async Task<RightModel> GetRight(string rightId)
    {
        return await GetByHashKey(rightId);
    }

    public async Task<string> SaveRight(RightModel rightModel)
    {
        var rightId = Guid.NewGuid().ToString();
        await SaveAsync(rightModel);

        return rightId;
    }
}

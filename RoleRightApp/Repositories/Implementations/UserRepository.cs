using Amazon.DynamoDBv2.DataModel;
using RoleRightApp.Repositories.Abstractions;
using RoleRightApp.Repositories.Models;

namespace RoleRightApp.Repositories.Implementations;

public class UserRepository : HashKeyOnlyRepositoryBase<UserModel, string>, IUserRepository
{
    public UserRepository(IDynamoDBContext dbContext) : base(dbContext)
    {
    }

    public async Task<UserModel> GetUser(string userId)
    {
        return await GetByHashKey(userId);
    }

    public async Task<List<UserModel>> GetAllUsers()
    {
        return await GetList();
    }

    public async Task<string> SaveUser(UserModel userModel)
    {
        var userId = Guid.NewGuid().ToString();
        await SaveAsync(userModel);

        return userId;
    }

    public Task<string> DeleteUser(string userId)
    {
        throw new NotImplementedException();
    }
}
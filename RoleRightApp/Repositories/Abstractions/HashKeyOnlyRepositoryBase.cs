using Amazon.DynamoDBv2.DataModel;

namespace RoleRightApp.Repositories.Abstractions;

/// <summary>
/// Generic Repository for Table that has only hash key
/// </summary>
/// <typeparam name="T">Object Type</typeparam>
/// <typeparam name="H">Hash Key Type</typeparam>
public class HashKeyOnlyRepositoryBase<T, H>
{
    private readonly IDynamoDBContext _dbContext;

    protected HashKeyOnlyRepositoryBase(IDynamoDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    protected async Task<List<T>> GetList()
    {
        var result = await _dbContext
            .ScanAsync<T>(Array.Empty<ScanCondition>())
            .GetRemainingAsync();

        return result;
    }

    protected async Task<T> GetByHashKey(H hashKey)
    {
        var result = await _dbContext.LoadAsync<T>(hashKey);
        return result;
    }

    protected async Task SaveAsync(T t)
    {
       await _dbContext.SaveAsync(t);
    }
}
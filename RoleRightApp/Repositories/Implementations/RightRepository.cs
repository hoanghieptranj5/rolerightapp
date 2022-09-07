﻿using Amazon.DynamoDBv2.DataModel;
using RoleRightApp.Repositories.Abstractions;
using RoleRightApp.Repositories.Models;

namespace RoleRightApp.Repositories.Implementations;

public class RightRepository : HashKeyOnlyRepositoryBase<RightModel, string>, IRightRepository
{
    public RightRepository(IDynamoDBContext dbContext) : base(dbContext)
    {
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
}

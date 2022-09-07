﻿using RoleRightApp.Repositories.Models;

namespace RoleRightApp.Repositories.Abstractions;

public interface IRightRepository
{
    Task<List<RightModel>> GetAllRights();
    Task<string> UpdateRight(RightModel rightModel);
}

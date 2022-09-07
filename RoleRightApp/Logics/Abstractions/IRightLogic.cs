﻿using RoleRightApp.Repositories.Models;
using RoleRightApp.RequestModels;

namespace RoleRightApp.Logics.Abstractions;

public interface IRightLogic
{
    Task<string> UpdateRight(RightModel right);
}
﻿using RoleRightApp.Mappers;

namespace RoleRightApp.ExtensionMethods;

public static class AutoMapperConfigurations
{
    public static void ConfigureAutoMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserMapperProfile).Assembly);
    }
}
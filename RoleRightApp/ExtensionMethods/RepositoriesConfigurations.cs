using RoleRightApp.Logics.Abstractions;
using RoleRightApp.Logics.Implementations;
using RoleRightApp.Repositories.Abstractions;
using RoleRightApp.Repositories.Implementations;

namespace RoleRightApp.ExtensionMethods;

public static class RepositoriesConfigurations
{
    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IUserLogic, UserLogic>();
    }
}
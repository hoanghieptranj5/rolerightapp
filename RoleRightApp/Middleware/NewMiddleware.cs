using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleRightApp.Middleware;

public class NewMiddleware
{
    private readonly RequestDelegate _next;

    public NewMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task Invoke(HttpContext httpContext)
    {
        httpContext.Response.WriteAsJsonAsync("hello hieu");
        // httpContext.Response.Redirect("/swagger/index.html");
        return _next(httpContext);
    }
}

public static class NewMiddlewareExtensions
{
    public static IApplicationBuilder UseNewMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<NewMiddleware>();
    }
}
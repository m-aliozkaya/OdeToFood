using Microsoft.AspNetCore.Builder;
using OdeToFood.Middlewares;

namespace OdeToFood.UI.Extensions;

static public class MyMiddlewareExtensions
{
    public static IApplicationBuilder UseHello(this IApplicationBuilder applicationBuilder)
    {
        return applicationBuilder.UseMiddleware<HelloMiddleware>();
    }
}

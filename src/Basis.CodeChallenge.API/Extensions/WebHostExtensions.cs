using Basis.CodeChallenge.Infra.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Basis.CodeChallenge.API.Extensions;

[ExcludeFromCodeCoverage]
public static class WebHostExtensions
{
    public static IApplicationBuilder UseDatabaseValidation(this IApplicationBuilder app)
    {
        try
        {
            using var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<EntityContext>();

            var created = dbContext.Database.EnsureCreated();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            //Just to avoid concurrent creation of the database between APIs
        }
      

        return app;
    }

    public static IApplicationBuilder UseDatabaseSeed(this IApplicationBuilder app)
    {
        try
        {
            using var scope = app.ApplicationServices.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<EntityContextSeed>();
            
        }
        catch
        {
            //Just to avoid concurrent seed of the database between APIs
        }
        return app;
    }
}

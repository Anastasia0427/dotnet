using Planner.DataAccess;
using Microsoft.EntityFrameworkCore;
using Planner.Service.Settings;

namespace Planner.Service.IoC;

public static class DbContextConfigurator
{
    public static void ConfigureService(IServiceCollection services, PlannerSettings settings)
    {
        services.AddDbContextFactory<PlannerDbContext>(
            options => { options.UseNpgsql(settings.PlannerDbContextConnectionString); },
            ServiceLifetime.Scoped);
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<PlannerDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate();
    }
}
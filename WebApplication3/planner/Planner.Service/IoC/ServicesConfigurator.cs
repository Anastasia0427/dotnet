using AutoMapper;
using Planner.BL.User.Manager;
using Planner.BL.User.Provider;
using Planner.DataAccess;
using Planner.DataAccess.Entities;
using Planner.Repository.Repository;
using Planner.Service.Settings;
using Microsoft.EntityFrameworkCore;
using Planner.BL.User;

namespace Planner.Service.IoC;

public static class ServicesConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        
        services.AddScoped<IRepository<UserEntity>>(x =>
            new Repository<UserEntity>(x.GetRequiredService<IDbContextFactory<PlannerDbContext>>()));
        
        services.AddScoped<IUserProvider>(x =>
            new UserProvider(x.GetRequiredService<IRepository<UserEntity>>(),
                x.GetRequiredService<IMapper>()));
        
        services.AddScoped<IUserManager>(x =>
            new UserManager(x.GetRequiredService<IRepository<UserEntity>>(),
                x.GetRequiredService<IMapper>()));
    }
}
using AutoMapper;
using Planner.BL.Mapper;
using Planner.Service.Mapper;

namespace Planner.Service.IoC;

public static class MapperConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<UserBLProfile>();
            config.AddProfile<UserServiceProfile>();
        });
    }
    
}


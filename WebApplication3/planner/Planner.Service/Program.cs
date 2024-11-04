using System.Collections.Immutable;
using Planner.Service.IoC;
using Planner.Service.Settings;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();
    
var settings = PlannerSettingsReader.Read(configuration);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

DbContextConfigurator.ConfigureService(builder.Services, settings);
SerilogConfigurator.ConfigureService(builder);
SwaggerConfigurator.ConfigureService(builder.Services);

var app = builder.Build(); 

SerilogConfigurator.ConfigureApplication(app);
SwaggerConfigurator.ConfigureApplication(app);
DbContextConfigurator.ConfigureApplication(app);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

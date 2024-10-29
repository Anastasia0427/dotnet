using System.Collections.Immutable;
using Planner.WebAPI.IoC;
using Planner.WebAPI.Settings;

var configuraion = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();
    
var settings = PlannerSettingsReader.Read(configuraion);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

SerilogConfigurator.ConfigureService(builder);
SwaggerConfigurator.ConfigureServices(builder.Services);

var app = builder.Build(); 

SerilogConfigurator.ConfigureApplication(app);
SwaggerConfigurator.ConfigureApplication(app);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

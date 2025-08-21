using Brp.Shared.DtoMappers;
using Brp.Shared.Infrastructure.HealthCheck;
using Brp.Shared.Infrastructure.Logging;
using Brp.Shared.Infrastructure.Utils;
using Brp.Shared.Validatie;
using Brp.Shared.Validatie.Middleware;
using BrpProxy.Middlewares;
using BrpProxy.Validators;
using HaalCentraal.BrpService.Extensions;
using HaalCentraal.BrpService.Middlewares;
using HaalCentraal.BrpService.Repositories;
using Serilog;

Log.Logger = SerilogHelpers.SetupSerilogBootstrapLogger();

try
{
    Log.Information("Starting {AppName} v{AppVersion}. TimeZone: {TimeZone}. Now: {TimeNow}",
                    AssemblyHelpers.Name, AssemblyHelpers.Version, TimeZoneInfo.Local.StandardName, DateTime.Now);

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddHttpContextAccessor();

    builder.SetupSerilog(Log.Logger);

    builder.SetupPersonenRequestValidation();

    builder.Services.AddSingleton<FieldsHelper>();
    SetupHelpers.AddBrpSharedDtoMappers();
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddControllers()
                    .ConfigureInvalidModelStateHandling()
                    .AddNewtonsoftJson();

    builder.Services.AddScoped<PersoonRepository>();

    builder.Services.AddHealthChecks();

    var app = builder.Build();

    app.SetupSerilogRequestLogging();

    app.SetupHealthCheckEndpoints(builder.Configuration, Log.Logger);

    app.UseMiddleware<RequestValidatieMiddleware>();

    app.UseMiddleware<AddAcceptGezagVersionHeaderMiddleware>();
    
    app.UseMiddleware<OverwriteResponseBodyMiddleware>();

    app.MapControllers();

    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "{AppName} terminated unexpectedly", AssemblyHelpers.Name);
}
finally
{
    await Log.CloseAndFlushAsync();
}

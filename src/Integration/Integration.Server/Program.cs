using PeakLogix.LogixPro.Common.Api.Authorization;
using PeakLogix.LogixPro.Common.Api.Extensions;
using PeakLogix.LogixPro.Common.Server;
using PeakLogix.LogixPro.Integration.Api.Extensions;
using PeakLogix.LogixPro.Integration.Shared.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults (telemetry, health checks, resilience)
builder.AddServiceDefaults();

//var dataConfig = DataConfigBuilder.Build(builder.Configuration);

// Add services to the container
if (builder.Environment.IsEnvironment("Testing"))
    builder.Services.AddTestJwtAuthentication();
else
    builder.Services.AddJwtBearerAuthentication(builder.Configuration);

builder.Services.AddPermissionAuthorization();
builder.Services.AddIntegrationApiServices(false);
builder.Services.AddStandardApiVersioning();

//----------------------------------------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseStandardApiPipeline();

app.MapEndpoints();
app.MapDefaultEndpoints();

// Enable API documentation in development
if (app.Environment.IsDevelopment())
    app.MapIntegrationApiDocumentation();

app.Services.GetRequiredService<PermissionRegistry>()
    .Register(IntegrationPermissions.Hierarchy);

app.Run();

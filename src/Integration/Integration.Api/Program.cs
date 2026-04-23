using PeakLogix.PickPro.Common.Api.Authorization;
using PeakLogix.PickPro.Common.Api.Extensions;
using PeakLogix.PickPro.Integration.Api.Extensions;
using PeakLogix.PickPro.Integration.Shared.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults (telemetry, health check (ping), resilience)
builder.AddServiceDefaults();


// Add services to the container
if (builder.Environment.IsEnvironment("Testing"))
	builder.Services.AddTestJwtAuthentication();
else
	builder.Services.AddJwtBearerAuthentication(builder.Configuration);

builder.Services.AddPermissionAuthorization();
builder.Services.AddIntegrationApiServices();
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

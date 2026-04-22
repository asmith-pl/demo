using PeakLogix.PickPro.App.Api.Extensions;
using PeakLogix.PickPro.App.Shared.Authorization;
using PeakLogix.PickPro.Common.Api.Authorization;
using PeakLogix.PickPro.Common.Api.Extensions;
using PeakLogix.PickPro.Common.Server;

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
builder.Services.AddAppApiServices(builder.Configuration, false);
builder.Services.AddStandardApiVersioning();
//builder.Services.AddDataServices(dataConfig);

//----------------------------------------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseStandardApiPipeline();

app.MapEndpoints();
app.MapDefaultEndpoints();

// Enable API documentation in development
if (app.Environment.IsDevelopment())
	app.MapAppApiDocumentation();

app.Services.GetRequiredService<PermissionRegistry>()
	.Register(AppPermissions.Hierarchy);

app.Run();

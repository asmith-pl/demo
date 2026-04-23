using PeakLogix.PickPro.Common.Api.Extensions;
using PeakLogix.PickPro.RelayAgent.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseWindowsService();

// Add service defaults (telemetry, health checks, resilience)
builder.AddServiceDefaults();

// Add services to the container
builder.Services.AddJwtBearerAuthentication(builder.Configuration);
builder.Services.AddPermissionAuthorization();
builder.Services.AddStandardApiVersioning();

builder.Services.AddRelayAgentApiServices();


//----------------------------------------------------------------------------------------------


var app = builder.Build();

// Configure the HTTP request pipeline
app.UseStandardApiPipeline();

app.MapEndpoints();
app.MapDefaultEndpoints();

// Enable API documentation in development
if (app.Environment.IsDevelopment())
	app.MapRelayAgentApiDocumentation();

app.Run();

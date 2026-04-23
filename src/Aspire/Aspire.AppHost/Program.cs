var builder = DistributedApplication.CreateBuilder(args);

// Auth microservice
var authServer = builder.AddProject<Projects.Auth_Server>("auth-server");

// Integration microservice
var integrationServer = builder.AddProject<Projects.Integration_Api>("integration-api")
    .WithEndpoint("https", e => e.Port = 5004);

// RelayAgent microservice
var relayAgentServer = builder.AddProject<Projects.RelayAgent_Api>("relayagent-api")
    .WithEndpoint("https", e => e.Port = 5005);

// AdAgent microservice
var adAgentServer = builder.AddProject<Projects.AdAgent_Api>("adagent-api")
    .WithEndpoint("https", e => e.Port = 5006);

try
{
    await builder.Build().RunAsync();
}
catch (OperationCanceledException)
{
    // Expected when Aspire.Hosting.Testing tears down the DistributedApplicationFactory.
}

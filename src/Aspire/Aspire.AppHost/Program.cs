var builder = DistributedApplication.CreateBuilder(args);

// Auth microservice
var authServer = builder.AddProject<Projects.Auth_Server>("auth-server");
//.WithHttpsEndpoint(port: 5002, name: "https");

// Integration microservice
var integrationServer = builder.AddProject<Projects.Integration_Api>("integration-api");
//.WithHttpsEndpoint(port: 5005, name: "https");

// AdAgent microservice
var adAgentServer = builder.AddProject<Projects.AdAgent_Api>("adagent-api");

try
{
    await builder.Build().RunAsync();
}
catch (OperationCanceledException)
{
    // Expected when Aspire.Hosting.Testing tears down the DistributedApplicationFactory.
}

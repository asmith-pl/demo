var builder = DistributedApplication.CreateBuilder(args);

// Auth microservice
var authServer = builder.AddProject<Projects.Auth_Server>("auth-server");
//.WithHttpsEndpoint(port: 5002, name: "https");

// App microservice  
var appServer = builder.AddProject<Projects.App_Server>("app-server")
	.WithReference(authServer);
//.WithHttpsEndpoint(port: 5003, name: "https");

// Integration microservice
var integrationServer = builder.AddProject<Projects.Integration_Server>("integration-server");
//.WithHttpsEndpoint(port: 5005, name: "https");

// AdAgent microservice
var adAgentServer = builder.AddProject<Projects.AdAgent_Server>("adagent-server");

try
{
    await builder.Build().RunAsync();
}
catch (OperationCanceledException)
{
    // Expected when Aspire.Hosting.Testing tears down the DistributedApplicationFactory.
}

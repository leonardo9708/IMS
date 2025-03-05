var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.IMS_ApiService>("apiservice");

builder.AddProject<Projects.IMS_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();

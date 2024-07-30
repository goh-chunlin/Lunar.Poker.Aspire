var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Lunar_Poker_Aspire_ApiService>("apiservice");

builder.AddProject<Projects.Lunar_Poker_Aspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();

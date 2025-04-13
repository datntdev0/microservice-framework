var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.datntdev_Microservices_Identity_Web_Host>("microservices-identity-web-host");

builder.Build().Run();

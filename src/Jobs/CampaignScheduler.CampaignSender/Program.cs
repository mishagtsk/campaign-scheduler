using CampaignScheduler.CampaignSender.Extensions;
using CampaignScheduler.CampaignSender.HostedServices;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<CampaignSenderWorker>();

var configuration = builder.Configuration;

builder.Services
    .AddCustomOptions(configuration)
    .AddCustomData(configuration)
    .AddCustomServices();

var host = builder.Build();
host.Run();

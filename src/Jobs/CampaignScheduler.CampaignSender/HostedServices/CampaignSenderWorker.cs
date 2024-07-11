using CampaignScheduler.CampaignSender.Options;
using CampaignScheduler.CampaignSender.Processors;
using Microsoft.Extensions.Options;

namespace CampaignScheduler.CampaignSender.HostedServices
{
    public class CampaignSenderWorker : BackgroundService
    {
        private readonly ILogger<CampaignSenderWorker> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly CampaignSenderOptions _options;

        public CampaignSenderWorker(
            ILogger<CampaignSenderWorker> logger, 
            IServiceScopeFactory serviceScopeFactory, 
            IOptions<CampaignSenderOptions> options)
        {
            _logger = logger;
            this._serviceScopeFactory = serviceScopeFactory;
            _options = options.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var campaignProcessor = scope.ServiceProvider.GetRequiredService<ICampaignsProcessor>();
                    await campaignProcessor.ProcessAsync(stoppingToken);
                }

                await Task.Delay(_options.DelayMilliseconds, stoppingToken);
            }
        }
    }
}

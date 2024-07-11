using CampaignScheduler.Data.Repositories;
using CampaignScheduler.CampaignSender.Options;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace CampaignScheduler.CampaignSender.Processors
{
    public class CampaignsProcessor : ICampaignsProcessor
    {
        private const int SimultaneousWrites = 1;

        private readonly string _sendsDirectory;

        private readonly ICampaignsRepository _campaignsRepository;
        private readonly ILogger<CampaignsProcessor> _logger;
        private readonly CampaignSenderOptions _options;
        private readonly ICampaignProcessor _campaignProcessor;
        private readonly IFileProcessor _fileProcessor;

        public CampaignsProcessor(
            ICampaignsRepository campaignsRepository, 
            ILogger<CampaignsProcessor> logger,
            IOptions<CampaignSenderOptions> options, 
            ICampaignProcessor campaignProcessor, IFileProcessor fileProcessor)
        {
            _campaignsRepository = campaignsRepository;
            _logger = logger;
            _options = options.Value;
            _campaignProcessor = campaignProcessor;
            _fileProcessor = fileProcessor;

            _sendsDirectory = $"{Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)}/Sends";
        }

        public async Task ProcessAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Start campaigns processing.");

            var campaigns = await _campaignsRepository.FilterCampaigns(cancellationToken);

            _logger.LogInformation("Found {TotalCount} campaigns to process.", campaigns.Count);

            _fileProcessor.CreateDirectory(_sendsDirectory);
            var filePath = BuildSendsFilePath(); 
            _fileProcessor.CreateFile(filePath);

            var processedCount = 0;

            using var semaphore = new SemaphoreSlim(SimultaneousWrites);

            await Parallel.ForEachAsync(
                campaigns,
                new ParallelOptions
                {
                    MaxDegreeOfParallelism = _options.DegreeOfParallelism ?? Environment.ProcessorCount,
                    CancellationToken = cancellationToken
                },
                async (campaign, token) =>
                {
                    await semaphore.WaitAsync(token);
                    try
                    {
                        await _campaignProcessor.ProcessAsync(campaign, filePath, token);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("Error processing campaign: {ex}", ex.Message);
                    }
                    finally
                    {
                        semaphore.Release();
                        processedCount++;
                    }
                });

            _logger.LogInformation("Finish campaigns processing. Sent: {ProcessedCount}/{TotalCount}.", processedCount, campaigns.Count);

        }

        private string BuildSendsFilePath()
        {
            return $"{_sendsDirectory}/sends-{DateTime.Now:yyyy-dd-M-HH-mm}.txt";
        }
    }
}

using CampaignScheduler.Models;

namespace CampaignScheduler.CampaignSender.Processors
{
    public interface ICampaignProcessor
    {
        Task ProcessAsync(Campaign? campaign, string fileToWrite, CancellationToken cancellationToken);
    }
}

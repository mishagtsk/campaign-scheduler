namespace CampaignScheduler.CampaignSender.Processors
{
    public interface ICampaignsProcessor
    {
        Task ProcessAsync(CancellationToken cancellationToken);
    }
}

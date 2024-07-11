using CampaignScheduler.Models;

namespace CampaignScheduler.Data.Repositories
{
    public interface ICampaignsRepository
    {
        Task AddCampaigns(ICollection<Campaign> campaigns, CancellationToken cancellationToken);
        Task<ICollection<Campaign?>> FilterCampaigns(CancellationToken cancellationToken);
        Task UpdateCampaign(Campaign campaign, CancellationToken cancellationToken);
    }
}

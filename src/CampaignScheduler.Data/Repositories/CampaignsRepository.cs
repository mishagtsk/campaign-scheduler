using CampaignScheduler.Models;
using Microsoft.EntityFrameworkCore;

namespace CampaignScheduler.Data.Repositories
{
    public class CampaignsRepository : ICampaignsRepository
    {
        private readonly CampaignSchedulingDbContext _context;

        public CampaignsRepository(CampaignSchedulingDbContext context)
        {
            _context = context;
        }

        public async Task AddCampaigns(ICollection<Campaign> campaigns, CancellationToken cancellationToken)
        {
            _context.Campaigns.AddRange(campaigns);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<ICollection<Campaign?>> FilterCampaigns(CancellationToken cancellationToken)
        {
             return await _context.Campaigns
                .Include(c => c.Customer)
                .Where(c => !c.IsSent
                    && c.Customer.CampaignSentDate == null || c.Customer.CampaignSentDate < DateTime.Now.Date)
                .GroupBy(c => c.Customer)
                .Select(gr =>
                    gr.OrderBy(x => x.Priority).ThenBy(x => x.TimeToSend).FirstOrDefault())
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateCampaign(Campaign campaign, CancellationToken cancellationToken)
        {
            _context.Campaigns.Update(campaign);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

using CampaignScheduler.Contracts.Scheduling;
using MediatR;

namespace CampaignScheduler.Commands.Scheduling
{
    public class ScheduleCampaignCommand : IRequest
    {
        public ICollection<CampaignDto> Campaigns { get; set; } = new List<CampaignDto>();
    }
}

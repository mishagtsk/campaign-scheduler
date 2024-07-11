namespace CampaignScheduler.Contracts.Scheduling
{
    public class CampaignDto
    {
        public required string Template { get; set; }
        public CustomerOptionsDto? CustomerOptions { get; set; }
        public TimeSpan TimeToSend { get; set; }
        public int Priority { get; set; }
    }
}

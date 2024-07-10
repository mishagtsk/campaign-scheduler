namespace CampaignScheduler.Contracts.Scheduling
{
    public class ScheduleDto
    {
        public string Template { get; set; }
        public CustomerOptionsDto CustomerOptions { get; set; }
        public TimeSpan TimeToSend { get; set; }
        public int Priority { get; set; }
    }
}

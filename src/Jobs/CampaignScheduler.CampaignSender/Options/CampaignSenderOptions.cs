namespace CampaignScheduler.CampaignSender.Options
{
    public class CampaignSenderOptions
    {
        public const string SectionName = "CampaignSender";

        public int? DegreeOfParallelism { get; set; }
        public int DelayMilliseconds { get; set; }
    }
}

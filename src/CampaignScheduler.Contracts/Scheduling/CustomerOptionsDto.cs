namespace CampaignScheduler.Contracts.Scheduling
{
    public class CustomerOptionsDto
    {
        public string? Gender { get; set; }
        public int? MinimalAge { get; set; }
        public string? City { get; set; }
        public int? MinimalDeposit { get; set; }
        public bool? IsNemCustomer { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CampaignScheduler.Models
{
    public class Campaign
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Template { get; set; }

        [Required]
        public TimeSpan TimeToSend { get; set; }

        [Required]
        public int Priority { get; set; }

        [Required]
        public bool IsSent { get; set; }

        public virtual Customer Customer { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CampaignScheduler.Models
{
    public class Customer
    {
        private ICollection<Campaign> _campaigns;

        public int Id { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [MaxLength(50)]
        public string Gender { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        public int Deposit { get; set; }

        [Required]
        public bool NewCustomer { get; set; }
        public DateTime? CampaignSentDate { get; set; }

        public virtual ICollection<Campaign> Campaigns
        {
            get => _campaigns ??= [];
            set => _campaigns = value;
        }
    }
}

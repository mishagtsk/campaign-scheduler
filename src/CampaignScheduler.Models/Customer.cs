using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignScheduler.Models
{
    public class Customer
    {
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

        public virtual ICollection<Campaign> Campaigns { get; set; }
    }
}

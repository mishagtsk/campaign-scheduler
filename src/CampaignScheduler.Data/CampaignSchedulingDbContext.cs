using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampaignScheduler.Models;

namespace CampaignScheduler.Data
{
    public class CampaignSchedulingDbContext : DbContext
    {
        public CampaignSchedulingDbContext(DbContextOptions<CampaignSchedulingDbContext> options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
    }
}

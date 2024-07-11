using CampaignScheduler.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CampaignScheduler.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CampaignSchedulingDbContext _context;
        
        public CustomerRepository(CampaignSchedulingDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Customer>> FilterCustomers(
            string? gender, 
            int? minimalAge, 
            string? city,
            int? minimalDeposit, 
            bool? isNewCustomer, 
            CancellationToken cancellationToken)
        {
            return await _context.Customers
                .Where(c =>
                    (gender.IsNullOrEmpty() || c.Gender == gender)
                    && (minimalAge == null || c.Age >= minimalAge)
                    && (city.IsNullOrEmpty() || c.City == city)
                    && (minimalDeposit == null || c.Deposit >= minimalDeposit)
                    && (isNewCustomer == null || c.NewCustomer == isNewCustomer))
                .ToListAsync(cancellationToken);
        }
    }
}

using CampaignScheduler.Models;

namespace CampaignScheduler.Data.Repositories
{
    public interface ICustomerRepository
    {
        Task<ICollection<Customer>> FilterCustomers(
            string? gender,
            int? minimalAge,
            string? city,
            int? minimalDeposit,
            bool? isNewCustomer,
            CancellationToken cancellationToken);
    }
}

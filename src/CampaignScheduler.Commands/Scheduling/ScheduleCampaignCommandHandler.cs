using CampaignScheduler.Data.Repositories;
using CampaignScheduler.Models;
using MediatR;

namespace CampaignScheduler.Commands.Scheduling
{
    public class ScheduleCampaignCommandHandler : IRequestHandler<ScheduleCampaignCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICampaignsRepository _campaignsRepository;

        public ScheduleCampaignCommandHandler(ICustomerRepository customerRepository, ICampaignsRepository campaignsRepository)
        {
            _customerRepository = customerRepository;
            _campaignsRepository = campaignsRepository;
        }

        public async Task Handle(ScheduleCampaignCommand request, CancellationToken cancellationToken)
        {
            var campaignsToAdd = new List<Campaign>();

            foreach (var scheduleDto in request.Campaigns)
            {
                var customers = await _customerRepository.FilterCustomers(
                    scheduleDto.CustomerOptions?.Gender,
                    scheduleDto.CustomerOptions?.MinimalAge, 
                    scheduleDto.CustomerOptions?.City,
                    scheduleDto.CustomerOptions?.MinimalDeposit, 
                    scheduleDto.CustomerOptions?.IsNemCustomer,
                    cancellationToken);

                campaignsToAdd.AddRange(customers.Select(customer => new Campaign
                {
                    IsSent = false,
                    Priority = scheduleDto.Priority,
                    Template = scheduleDto.Template,
                    TimeToSend = scheduleDto.TimeToSend,
                    Customer = customer
                }));
            }

            await _campaignsRepository.AddCampaigns(campaignsToAdd, cancellationToken);
        }
    }
}

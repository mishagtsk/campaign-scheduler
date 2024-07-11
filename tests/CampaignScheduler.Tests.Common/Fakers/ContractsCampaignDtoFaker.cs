using Bogus;
using CampaignScheduler.Contracts.Scheduling;

namespace CampaignScheduler.Tests.Common.Fakers
{
    public static class ContractsCampaignDtoFaker
    {
        public static Faker<CampaignDto> Default => new Faker<CampaignDto>()
            .RuleFor(x => x.Template, f => f.Random.Word())
            .RuleFor(x => x.Priority, f => f.Random.Int(1, 5))
            .RuleFor(x => x.TimeToSend, f => f.Date.Timespan())
            .RuleFor(x => x.CustomerOptions, ContractCustomerOptionsDtoFaker.Default.Generate());
    }
}

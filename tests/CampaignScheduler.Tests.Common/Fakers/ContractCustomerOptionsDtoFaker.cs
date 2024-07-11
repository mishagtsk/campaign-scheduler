using Bogus;
using CampaignScheduler.Contracts.Scheduling;

namespace CampaignScheduler.Tests.Common.Fakers
{
    public static class ContractCustomerOptionsDtoFaker
    {
        public static Faker<CustomerOptionsDto> Default => new Faker<CustomerOptionsDto>()
            .RuleFor(x => x.Gender, f => f.Person.Gender.ToString())
            .RuleFor(x => x.MinimalAge, f => f.Random.Int(10, 99))
            .RuleFor(x => x.City, f => f.Address.City())
            .RuleFor(x => x.MinimalDeposit, f => f.Random.Int(100, 10000))
            .RuleFor(x => x.IsNemCustomer, f => f.Random.Bool());
    }
}

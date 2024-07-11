using CampaignScheduler.WebApi.Models;
using FluentValidation;

namespace CampaignScheduler.WebApi.Validation
{
    public class CustomerOptionsDtoValidator : AbstractValidator<CustomerOptionsDto>
    {
        public CustomerOptionsDtoValidator()
        {
            RuleFor(x => x.MinimalAge).GreaterThanOrEqualTo(0).When(x => x != null);
            RuleFor(x => x.MinimalDeposit).GreaterThanOrEqualTo(0).When(x => x != null);
        }
    }
}

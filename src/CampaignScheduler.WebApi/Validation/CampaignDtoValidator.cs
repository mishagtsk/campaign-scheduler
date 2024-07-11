using CampaignScheduler.WebApi.Models;
using FluentValidation;

namespace CampaignScheduler.WebApi.Validation
{
    public class CampaignDtoValidator : AbstractValidator<CampaignDto>
    {
        public CampaignDtoValidator()
        {
            RuleFor(x => x.Template).NotNull().MaximumLength(200);
            RuleFor(x => x.Priority).GreaterThan(0);
            RuleFor(x => x.CustomerOptions).SetValidator(new CustomerOptionsDtoValidator()).When(x => x.CustomerOptions != null);
        }
    }
}

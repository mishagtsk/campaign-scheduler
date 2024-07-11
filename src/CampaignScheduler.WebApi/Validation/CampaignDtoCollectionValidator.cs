using CampaignScheduler.WebApi.Models;
using FluentValidation;

namespace CampaignScheduler.WebApi.Validation
{
    public class CampaignDtoCollectionValidator : AbstractValidator<CampaignDto[]>
    {
        public CampaignDtoCollectionValidator()
        {
            RuleForEach(self => self).SetValidator(new CampaignDtoValidator());
        }
    }
}

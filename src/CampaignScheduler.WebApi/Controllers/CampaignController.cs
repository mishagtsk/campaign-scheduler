using AutoMapper;
using CampaignScheduler.Commands.Scheduling;
using CampaignScheduler.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CampaignScheduler.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/campaign")]
    [AllowAnonymous]
    public class CampaignController
    {
        [HttpPost("schedule")]
        public async Task<IActionResult> ScheduleCampaign(
            [FromBody] CampaignDto[] campaigns,
            [FromServices] IMapper mapper,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken)
        {
            ScheduleCampaignCommand command = new ScheduleCampaignCommand
            {
                Campaigns = mapper.Map<ICollection<Contracts.Scheduling.CampaignDto>>(campaigns)
            };

            await mediator.Send(command, cancellationToken);

            return new OkResult();
        }
    }
}

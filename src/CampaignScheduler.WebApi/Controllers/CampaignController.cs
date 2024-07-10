using AutoMapper;
using CampaignScheduler.Commands.Scheduling;
using CampaignScheduler.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CampaignScheduler.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/campaign")]
    public class CampaignController
    {
        [HttpPost("schedule")]
        public async Task<IActionResult> ScheduleCampaign(
            [FromBody] ScheduleDto scheduleDto,
            [FromServices] IMapper mapper,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken)
        {
            ScheduleCampaignCommand command = new ScheduleCampaignCommand
            {
                Schedule = mapper.Map<Contracts.Scheduling.ScheduleDto>(scheduleDto)
            };

            await mediator.Send(command, cancellationToken);

            return new OkResult();
        }
    }
}

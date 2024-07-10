using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CampaignScheduler.Commands.Scheduling
{
    public class ScheduleCampaignCommandHandler : IRequestHandler<ScheduleCampaignCommand>
    {
        public Task Handle(ScheduleCampaignCommand request, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

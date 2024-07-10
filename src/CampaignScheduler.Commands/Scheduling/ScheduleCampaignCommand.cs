using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampaignScheduler.Contracts.Scheduling;
using MediatR;

namespace CampaignScheduler.Commands.Scheduling
{
    public class ScheduleCampaignCommand : IRequest
    {
        public ScheduleDto Schedule { get; set; }
    }
}

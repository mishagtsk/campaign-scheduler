using AutoMapper;
using CampaignScheduler.WebApi.Models;

namespace CampaignScheduler.WebApi.Mappings
{
    public class ScheduleCampaignProfile : Profile
    {
        public ScheduleCampaignProfile()
        {
            CreateMap<ScheduleDto, Contracts.Scheduling.ScheduleDto>()
                .ForMember(x => x.Priority, m => m.MapFrom(s => s.Priority))
                .ForMember(x => x.Template, m => m.MapFrom(s => s.Template))
                .ForMember(x => x.TimeToSend, m => m.MapFrom(s => s.TimeToSend))
                .ForMember(x => x.CustomerOptions, m => m.MapFrom(s => s.CustomerOptions));

            CreateMap<CustomerOptionsDto, Contracts.Scheduling.CustomerOptionsDto>()
                .ForMember(x => x.City, m => m.MapFrom(s => s.City))
                .ForMember(x => x.Gender, m => m.MapFrom(s => s.Gender))
                .ForMember(x => x.MinimalAge, m => m.MapFrom(s => s.MinimalAge))
                .ForMember(x => x.MinimalDeposit, m => m.MapFrom(s => s.MinimalDeposit))
                .ForMember(x => x.IsNemCustomer, m => m.MapFrom(s => s.IsNemCustomer));
        }
    }
}

using CampaignScheduler.CampaignSender.Options;
using CampaignScheduler.CampaignSender.Processors;
using CampaignScheduler.Data;
using CampaignScheduler.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CampaignScheduler.CampaignSender.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            services.Configure<CampaignSenderOptions>(configuration.GetSection(CampaignSenderOptions.SectionName));

            return services;
        }

        public static IServiceCollection AddCustomData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CampaignSchedulingDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DbContext")));

            services.AddScoped<ICampaignsRepository, CampaignsRepository>();

            return services;
        }

        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ICampaignsProcessor, CampaignsProcessor>();
            services.AddScoped<ICampaignProcessor, CampaignProcessor>();
            services.AddScoped<IFileProcessor, FileProcessor>();

            return services;
        }
    }
}

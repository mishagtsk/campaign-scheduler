using CampaignScheduler.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CampaignScheduler.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<CampaignSchedulingDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DbContext")));

            return services;
        }

        public static IServiceCollection AddMappingProfiles(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assembly);

            return services;
        }
    }
}

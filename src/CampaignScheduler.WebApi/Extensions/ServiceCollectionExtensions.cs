using CampaignScheduler.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CampaignScheduler.Data.Repositories;
using FluentValidation.AspNetCore;
using FluentValidation;
using CampaignScheduler.WebApi.Validation;

namespace CampaignScheduler.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<CampaignSchedulingDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DbContext")));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICampaignsRepository, CampaignsRepository>();

            return services;
        }

        public static IServiceCollection AddMappingProfiles(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assembly);

            return services;
        }

        public static IServiceCollection AddCustomValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();

            services.AddValidatorsFromAssemblyContaining<CampaignDtoValidator>();

            return services;
        }
    }
}

using Merchant.Todont.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Merchant.Todont.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config) =>
            services.AddDbContext<TodontContext>(options =>
                options.UseNpgsql(config.GetConnectionString("TodontContext")));
    }
}
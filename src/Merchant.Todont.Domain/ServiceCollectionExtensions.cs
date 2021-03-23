using Merchant.Todont.Domain.Habits;
using Merchant.Todont.Domain.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Merchant.Todont.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services) =>
            services
                .AddScoped<IUsersService, UsersService>()
                .AddScoped<IHabitsService, HabitsService>();

    }
}
using Merchant.Todont.Domain.Habits;
using Merchant.Todont.Domain.Users;
using Merchant.Todont.Infrastructure.Data.Context;
using Merchant.Todont.Infrastructure.Data.Queries;
using Merchant.Todont.Infrastructure.Data.Repositories;
using Merchant.Todont.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Merchant.Todont.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config) =>
            services
                .AddSingleton<IIdentityContext, TestIdentityContext>()
                .AddDbContext<TodontContext>(options => 
                    options.UseNpgsql(config.GetConnectionString("TodontContext"), 
                    builder => builder.MigrationsAssembly("Merchant.Todont.Web")), 
                    ServiceLifetime.Transient)
                .AddScoped<IHabitQueries, HabitQueries>()
                .AddScoped<IUserQueries, UserQueries>()
                .AddTransient<IUsersRepository, UsersRepository>()
                .AddTransient<IHabitsRepository, HabitsRepository>();
    }
}
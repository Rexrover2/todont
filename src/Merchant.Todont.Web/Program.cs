using System.Linq;
using System.Threading.Tasks;
using Merchant.Todont.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Merchant.Todont.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();
            await ApplyMigrations(host);
            await host.RunAsync();
        }

        private static async Task ApplyMigrations(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<TodontContext>();
            var migrations =  await db.Database.GetPendingMigrationsAsync();
            if (migrations.Any()) await db.Database.MigrateAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
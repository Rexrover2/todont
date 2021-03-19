using Microsoft.EntityFrameworkCore;

namespace Merchant.Todont.Infrastructure.Data.Context
{
    public class TodontContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Habit> Habits => Set<Habit>();
        public DbSet<Entry> Entries => Set<Entry>();
        public TodontContext(DbContextOptions<TodontContext> options) : base(options) { }
    }
}
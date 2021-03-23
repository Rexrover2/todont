using Microsoft.EntityFrameworkCore;

namespace Merchant.Todont.Infrastructure.Data.Context
{
    public class TodontContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Habit> Habits => Set<Habit>();
        public DbSet<HabitEntry> HabitEntries => Set<HabitEntry>();
        public TodontContext(DbContextOptions<TodontContext> options) : base(options) { }
    }
}
using System;

namespace Merchant.Todont.Infrastructure.Data.Context
{
    public class HabitEntry
    {
        public Guid Id { get; set; }
        public Guid HabitId { get; set; }
        public Habit Habit { get; set; } = default!;
        public DateTimeOffset Created { get; set; }
        public string Notes { get; set; } = "";
        public Domain.Habits.HabitEntry ToDomain() => new Domain.Habits.HabitEntry(Id, HabitId, Created, Notes);
    }
}
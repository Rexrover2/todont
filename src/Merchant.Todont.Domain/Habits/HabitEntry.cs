using System;

namespace Merchant.Todont.Domain.Habits
{
    public class HabitEntry
    {
        public Guid Id { get; }
        public Guid HabitId { get; }
        public DateTimeOffset Created { get; }
        public string Notes { get; }

        public HabitEntry(Guid id, Guid habitId, DateTimeOffset created, string notes)
        {
            Id = id;
            Created = created;
            Notes = notes;
        }
    }
}
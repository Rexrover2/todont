using System;

namespace Merchant.Todont.Domain.Habits
{
    public class HabitEntry
    {
        public Guid Id { get; }
        public Guid HabitId { get; }
        public Guid UserId { get; }
        public DateTimeOffset Created { get; }
        public string Notes { get; }

        public HabitEntry(Guid id, Guid habitId, Guid userId, DateTimeOffset created, string notes)
        {
            Id = id;
            HabitId = habitId;
            UserId = userId;
            Created = created;
            Notes = notes;
        }
    }
}
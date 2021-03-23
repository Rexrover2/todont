using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Merchant.Todont.Domain.Habits
{
    public class Habit
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; } 
        public DateTimeOffset Created { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public IReadOnlyList<HabitEntry> Entries { get; set; } = ImmutableArray<HabitEntry>.Empty;
        public IReadOnlyList<HabitStreak> Streaks { get; set; } = ImmutableArray<HabitStreak>.Empty;
    }
}
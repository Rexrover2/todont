using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Merchant.Todont.Domain.Habits
{
    public interface IHabitsService
    {
        Task<Habit> GetHabitById(Guid id);
        Task<IReadOnlyList<Habit>> GetHabitsByUserId(Guid userId);
        Task<Habit> SaveHabit(Habit habit);
        Task<HabitEntry> SaveHabitEntry(HabitEntry entry);
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Merchant.Todont.Domain.Habits
{
    public interface IHabitsRepository
    {
        Task<IReadOnlyList<Habit>> LoadByUserId(Guid userId);
        Task<Habit> Load(Guid id);
        Task<bool> Exists(Guid id);
        Task<Habit> Insert(Habit habit);
        Task<Habit> Update(Habit habit);
        Task<bool> EntryExists(Guid entryId);
        Task<HabitEntry> InsertEntry(HabitEntry entry);
        Task<HabitEntry> UpdateEntry(HabitEntry entry);
    }
}
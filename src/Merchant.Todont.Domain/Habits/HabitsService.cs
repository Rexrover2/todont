using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace Merchant.Todont.Domain.Habits
{
    public class HabitsService : IHabitsService
    {
        private readonly IHabitsRepository _habits;
        
        public HabitsService(IHabitsRepository habits)
        {
            _habits = habits;
        }

        public async Task<Habit> GetHabitById(Guid id)
        {
            var habit =  await _habits.Load(id);
            habit.Streaks = CalculateStreaks(habit);
            return habit;
        }

        public async Task<IReadOnlyList<Habit>> GetHabitsByUserId(Guid userId)
        {
            var habits = await _habits.LoadByUserId(userId);
            foreach (var habit in habits)
            {
                habit.Streaks = CalculateStreaks(habit);
            }
            return habits;
        }

        public async Task<Habit> SaveHabit(Habit habit)
        {
            if (!await _habits.Exists(habit.Id))
            {
                return await _habits.Insert(habit);
            }
            else
            {
                return await _habits.Update(habit);
            }
        }

        public async Task<HabitEntry> SaveHabitEntry(HabitEntry entry)
        {
            if (!await _habits.EntryExists(entry.Id))
            {
                return await _habits.InsertEntry(entry);
            }
            else
            {
                return await _habits.UpdateEntry(entry);
            }
        }

        private IReadOnlyList<HabitStreak> CalculateStreaks(Habit habit)
        {
            var last = habit.Created.Date;
            var dates = habit.Entries
                .Select(z => z.Created.Date)
                .Distinct()
                .OrderBy(z => z)
                .ToImmutableArray();
            
            var result = ImmutableArray<HabitStreak>.Empty;
            
            foreach (var date in dates)
            {
                var days = (int)(date - last).TotalDays;
                if (days > 1)
                {
                    result = result.Add(new HabitStreak(last, date, days));
                }
                
                last = date;
            }
            
            var today = DateTime.Today;
            if (last != today)
            {
                var days = (int)(today - last).TotalDays;
                result = result.Add(new HabitStreak(last, today, days));
            }
            
            return result;
        }
    }
}
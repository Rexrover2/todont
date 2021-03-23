using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merchant.Todont.Domain.Habits;
using Merchant.Todont.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Habit = Merchant.Todont.Domain.Habits.Habit;
using HabitEntry = Merchant.Todont.Domain.Habits.HabitEntry;

namespace Merchant.Todont.Infrastructure.Data.Repositories
{
    public class HabitsRepository : IHabitsRepository
    {
        private readonly TodontContext _db;
        
        public HabitsRepository(TodontContext db)
        {
            _db = db;
        }
        
        public async Task<IReadOnlyList<Habit>> LoadByUserId(Guid userId) => (await _db.Habits.AsNoTracking().Where(z => z.UserId == userId).ToArrayAsync()).Select(z => z.ToDomain()).ToArray();
        public async Task<Habit> Load(Guid id) => (await _db.Habits.AsNoTracking().Where(z => z.Id == id).SingleAsync()).ToDomain();
        public async Task<bool> Exists(Guid id) => await _db.Habits.AsNoTracking().Where(z => z.Id == id).AnyAsync();
        public async Task<Habit> Insert(Habit habit)
        {
            var entity = new Infrastructure.Data.Context.Habit
            {
                Id = habit.Id,
                Created = habit.Created,
                Description = habit.Description,
                Name = habit.Name,
                UserId = habit.UserId
            };
            await _db.Habits.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity.ToDomain();
        }
        

        public async Task<Habit> Update(Habit habit)
        {
            var entity = await _db.Habits.Where(z => z.Id == habit.Id).SingleOrDefaultAsync();
            entity.Description = habit.Description;
            entity.Name = habit.Name;
            await _db.SaveChangesAsync();
            return entity.ToDomain();
        }
        
        public async Task<bool> EntryExists(Guid entryId) => await _db.HabitEntries.AsNoTracking().Where(z => z.Id == entryId).AnyAsync();

        public async Task<HabitEntry> InsertEntry(HabitEntry entry)
        {
            var entity = new Context.HabitEntry
            {
                Id = entry.Id,
                Notes = entry.Notes,
                Created = entry.Created,
                HabitId = entry.HabitId
            };
            await _db.HabitEntries.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity.ToDomain();
        }

        public async Task<HabitEntry> UpdateEntry(HabitEntry entry)
        {
            var entity = await _db.HabitEntries.Where(z => z.Id == entry.Id).SingleAsync();
            entity.Notes = entry.Notes;
            await _db.SaveChangesAsync();
            return entity.ToDomain();
        }
        
    }
}
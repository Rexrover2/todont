using System;
using System.Linq;
using System.Threading.Tasks;
using Merchant.Todont.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Merchant.Todont.Infrastructure.Data.Queries
{
    public class HabitQueries : IHabitQueries
    {
        private readonly TodontContext _db;
        public HabitQueries(TodontContext db) => _db = db;
        public async Task<Habit> GetById(Guid habitId) => await _db.Habits.AsNoTracking().Where(z => z.Id == habitId).SingleAsync();
        public IQueryable<Habit> GetByUserId(Guid userId) => _db.Habits.AsNoTracking().Where(z => z.UserId == userId);
        public IQueryable<HabitEntry> GetEntries(Guid habitId) => _db.HabitEntries.AsNoTracking().Where(z => z.HabitId == habitId);
    }
}
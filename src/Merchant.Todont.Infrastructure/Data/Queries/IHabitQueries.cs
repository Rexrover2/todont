using System;
using System.Linq;
using System.Threading.Tasks;
using Merchant.Todont.Infrastructure.Data.Context;

namespace Merchant.Todont.Infrastructure.Data.Queries
{
    public interface IHabitQueries
    {
        Task<Habit> GetById(Guid habitId);
        IQueryable<Habit> GetByUserId(Guid userId);
        IQueryable<HabitEntry> GetEntries(Guid habitId);
    }
}
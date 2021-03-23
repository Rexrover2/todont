using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotChocolate;
using Merchant.Todont.Infrastructure.Data.Queries;

namespace Merchant.Todont.Api.Types.Habits
{
    public class HabitEntry
    {
        public Guid Id { get; set; }
        public Guid HabitId { get; set; }
        public async Task<Habit> Habit([Service] IHabitQueries queries) => Habits.Habit.FromData(await queries.GetById(HabitId));
        public DateTimeOffset Created { get; set; }
        
        #region Mapping
        
        public static Expression<Func<Infrastructure.Data.Context.HabitEntry, HabitEntry>> Projection { get; } = entry => new HabitEntry
        {
            Id = entry.Id,
            Created = entry.Created,
            HabitId = entry.HabitId,
        };

        public static HabitEntry FromDomain(Domain.Habits.HabitEntry entry) => new HabitEntry
        {
            Id = entry.Id,
            Created = entry.Created,
            HabitId = entry.HabitId,
        };
        
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotChocolate;
using Merchant.Todont.Api.Types.Users;
using Merchant.Todont.Domain.Habits;
using Merchant.Todont.Infrastructure.Data.Queries;

namespace Merchant.Todont.Api.Types.Habits
{
    public class Habit
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public async Task<User> User([Service] IUserQueries queries) => Users.User.FromData(await queries.GetById(UserId));
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public async Task<IReadOnlyList<HabitStreak>> Streaks([Service] IHabitsService service) => (await service.GetHabitById(Id)).Streaks.Select(HabitStreak.FromDomain).ToArray();
        public IQueryable<HabitEntry> Entries([Service] IHabitQueries queries) => queries.GetEntries(Id).Select(HabitEntry.Projection);
        
        #region Mapping
        
        public static Expression<Func<Infrastructure.Data.Context.Habit, Habit>> Projection { get; } = habit => new Habit
        {
            Id = habit.Id,
            UserId = habit.UserId,
            Name = habit.Name,
            Description = habit.Description
        };
        
        public static Func<Infrastructure.Data.Context.Habit, Habit> FromData { get; } = Projection.Compile();
        
        public static Habit FromDomain(Domain.Habits.Habit habit) => new Habit
        {
            Id = habit.Id,
            UserId = habit.UserId,
            Name = habit.Name,
            Description = habit.Description,
        };
        
        #endregion
    }
}
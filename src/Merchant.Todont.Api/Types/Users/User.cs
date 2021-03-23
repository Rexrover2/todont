using System;
using System.Linq;
using System.Linq.Expressions;
using HotChocolate;
using Merchant.Todont.Api.Types.Habits;
using Merchant.Todont.Infrastructure.Data.Queries;

namespace Merchant.Todont.Api.Types.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public IQueryable<Habit> Habits([Service] IHabitQueries queries) => queries.GetByUserId(Id).Select(Habit.Projection);
        public static Expression<Func<Infrastructure.Data.Context.User, User>> Projection { get; } = user => new User
        {
            Id = user.Id
        };
        
        public static Func<Infrastructure.Data.Context.User, User> FromData { get; } = Projection.Compile();
    }
}
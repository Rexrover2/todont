using System.Security.Claims;
using System.Threading.Tasks;
using HotChocolate;
using Merchant.Todont.Api.Types.Habits;
using Merchant.Todont.Domain.Habits;
using Merchant.Todont.Domain.Users;
using Merchant.Todont.Infrastructure.Identity;
using Habit = Merchant.Todont.Api.Types.Habits.Habit;
using HabitEntry = Merchant.Todont.Api.Types.Habits.HabitEntry;

namespace Merchant.Todont.Api.Types
{
    public class Mutation
    {
        public async Task<Habit> SaveHabit(
            [Service] IHabitsService habits, 
            [Service] IUsersService users,
            [Service] IIdentityContext identity,
            HabitInput input)
        {
            await users.EnsureCreated(identity.UserId);
            return Habit.FromDomain(await habits.SaveHabit(HabitInput.ToDomain(input, identity.UserId)));
        }

        public async Task<HabitEntry> SaveHabitEntry(
            [Service] IHabitsService habits,
            [Service] IUsersService users,
            [Service] IIdentityContext identity,
            HabitEntryInput input
        )
        {
            await users.EnsureCreated(identity.UserId);
            return HabitEntry.FromDomain(await habits.SaveHabitEntry(HabitEntryInput.ToDomain(input, identity.UserId)));
        }
    }
}
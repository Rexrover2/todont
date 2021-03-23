using System.Security.Claims;
using System.Threading.Tasks;
using HotChocolate;
using Merchant.Todont.Api.Types.Habits;
using Merchant.Todont.Domain.Habits;
using Merchant.Todont.Infrastructure.Identity;
using Habit = Merchant.Todont.Api.Types.Habits.Habit;
using HabitEntry = Merchant.Todont.Api.Types.Habits.HabitEntry;

namespace Merchant.Todont.Api.Types
{
    public class Mutation
    {
        public async Task<Habit> SaveHabit(
            [Service] IHabitsService service, 
            [Service] IIdentityContext identity,
            HabitInput input)
        {
            ClaimsPrincipal.Current.FindFirst(ClaimTypes.Email);
            return Habit.FromDomain(await service.SaveHabit(HabitInput.ToDomain(input, identity.UserId)));
        }

        public async Task<HabitEntry> SaveHabitEntry(
            [Service] IHabitsService service,
            [Service] IIdentityContext identity,
            HabitEntryInput input
        ) => HabitEntry.FromDomain(await service.SaveHabitEntry(HabitEntryInput.ToDomain(input)));
    }
}
using System;

namespace Merchant.Todont.Api.Types.Habits
{
    public class HabitEntryInput
    {
        public Guid? Id { get; set; }
        public Guid HabitId { get; set; }
        public string Notes { get; set; } = "";

        public static Domain.Habits.HabitEntry ToDomain(HabitEntryInput input) => new Domain.Habits.HabitEntry(
            input.Id ?? Guid.NewGuid(),
            input.HabitId,
            DateTimeOffset.Now,
            input.Notes
        );
    }
}
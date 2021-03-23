using System;

namespace Merchant.Todont.Api.Types.Habits
{
    public class HabitInput
    {
        public Guid? Id { get; set; } = null;
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public static Domain.Habits.Habit ToDomain(HabitInput input, Guid userId) => new Domain.Habits.Habit
        {
            Id = input.Id ?? Guid.NewGuid(),
            UserId = userId,
            Created = DateTimeOffset.Now,
            Description = input.Description,
            Name = input.Name,
        };
    }
}
using System;

namespace Merchant.Todont.Infrastructure.Data.Context
{
    public class Habit
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTimeOffset Created { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public Domain.Habits.Habit ToDomain() => new Domain.Habits.Habit
        {
            Id = Id,
            UserId = UserId,
            Name = Name,
            Created = Created,
            Description = Description
        };
    }
}
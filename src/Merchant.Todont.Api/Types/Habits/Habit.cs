using System;

namespace Merchant.Todont.Api.Types.Habits
{
    public class Habit
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
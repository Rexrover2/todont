using System;

namespace Merchant.Todont.Api.Types.Habits
{
    public class HabitEntry
    {
        public Guid Id { get; set; }
        public Guid HabitId { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}
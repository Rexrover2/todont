using System;

namespace Merchant.Todont.Api.Types.Habits
{
    public class HabitStreak
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int Days { get; set; }
        
        public static HabitStreak FromDomain(Domain.Habits.HabitStreak streak) => new HabitStreak
        {
            FromDate = streak.FromDate,
            ToDate = streak.ToDate,
            Days = streak.Days
        };
    }
}
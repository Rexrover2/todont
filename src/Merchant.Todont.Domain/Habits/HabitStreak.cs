using System;

namespace Merchant.Todont.Domain.Habits
{
    public class HabitStreak
    {
        public DateTime FromDate { get; }
        public DateTime ToDate { get; }
        public int Days { get; }

        public HabitStreak(DateTime fromDate, DateTime toDate, int days)
        {
            FromDate = fromDate;
            ToDate = toDate;
            Days = days;
        }
    } 
}
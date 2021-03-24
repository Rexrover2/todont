using System;
using System.Collections.Generic;

namespace Merchant.Todont.Infrastructure.Data.Context
{
    public class User
    {
        public Guid Id { get; set; }
        public List<Habit> Habits { get; set; } = new List<Habit>();
    }
}
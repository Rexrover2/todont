using System;
using Merchant.Todont.Enums;

namespace Merchant.Todont.Infrastructure.Data.Context
{
    public class Entry
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTimeOffset Created { get; set; }
        public EntryStatus Status { get; set; }
        public string Notes { get; set; } = "";
    }
}
using System;
using System.Linq;
using System.Threading.Tasks;
using Merchant.Todont.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Merchant.Todont.Infrastructure.Data.Queries
{
    public class UserQueries : IUserQueries
    {
        private readonly TodontContext _db;
        public UserQueries(TodontContext db) => _db = db;
        public async Task<User> GetById(Guid userId) => await _db.Users.Where(z => z.Id == userId).SingleAsync();
    }
}
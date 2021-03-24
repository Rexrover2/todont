using System;
using System.Linq;
using System.Threading.Tasks;
using Merchant.Todont.Domain.Users;
using Merchant.Todont.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using User = Merchant.Todont.Domain.Users.User;

namespace Merchant.Todont.Infrastructure.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly TodontContext _db;
        
        public UsersRepository(TodontContext db)
        {
            _db = db;
        }
        
        public async Task<User> LoadOrInsert(Guid id)
        {
            var entity = await _db.Users.Where(z => z.Id == id).SingleOrDefaultAsync();
            if (entity == null)
            {
                entity = new Context.User
                {
                    Id = id
                };
                await _db.Users.AddAsync(entity);
                await _db.SaveChangesAsync();
            }

            return entity.ToDomain();
        }
    }
}
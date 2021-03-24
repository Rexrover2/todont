using System;
using System.Threading.Tasks;

namespace Merchant.Todont.Domain.Users
{
    public class UsersService : IUsersService
    {
        public IUsersRepository _users;

        public UsersService(IUsersRepository users)
        {
            _users = users;
        }
        
        public async Task<User> EnsureCreated(Guid id)
        {
            return await _users.LoadOrInsert(id);
        }
    }
}
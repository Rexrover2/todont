using System;
using System.Threading.Tasks;

namespace Merchant.Todont.Domain.Users
{
    public interface IUsersRepository
    {
        Task<User> LoadOrInsert(Guid id);
    }
}
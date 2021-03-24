using System;
using System.Threading.Tasks;

namespace Merchant.Todont.Domain.Users
{
    public interface IUsersService
    {
        Task<User> EnsureCreated(Guid id);
    }
}
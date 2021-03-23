using System;
using System.Threading.Tasks;
using Merchant.Todont.Infrastructure.Data.Context;

namespace Merchant.Todont.Infrastructure.Data.Queries
{
    public interface IUserQueries
    {
        Task<User> GetById(Guid userId);
    }
}
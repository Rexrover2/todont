using HotChocolate;
using Merchant.Todont.Api.Types.Users;
using Merchant.Todont.Infrastructure.Identity;

namespace Merchant.Todont.Api.Types
{
    public class Query
    {
        public User CurrentUser([Service] IIdentityContext principal) => new User { Id = principal.UserId };
    }
}
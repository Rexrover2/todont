using System;

namespace Merchant.Todont.Infrastructure.Identity
{
    public interface IIdentityContext
    {
        Guid UserId { get; }
    }
}
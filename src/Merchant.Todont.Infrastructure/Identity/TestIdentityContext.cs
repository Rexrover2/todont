using System;

namespace Merchant.Todont.Infrastructure.Identity
{
    public class TestIdentityContext : IIdentityContext
    {
        public Guid UserId { get; } = Guid.Parse("adaf15a9-2692-41fe-8fa6-4d6f34371b8f");
    }
}
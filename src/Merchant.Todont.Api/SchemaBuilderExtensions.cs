using HotChocolate;
using Merchant.Todont.Api.Types;

namespace Merchant.Todont.Api
{
    public static class SchemaExtensions
    {
        public static ISchemaBuilder AddApi(this ISchemaBuilder builder) =>
            builder
                .AddQueryType<Query>()
                .AddMutationType<Mutation>();
    }
}
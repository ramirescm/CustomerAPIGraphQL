using CustomerAPIGraphQL.Model;
using HotChocolate;
using MongoDB.Driver;

namespace CustomerAPIGraphQL.Resolvers;

public class CustomerNodeResolver
{
    public Task<Customer> ResolveAsync(
        [Service] IMongoCollection<Customer> collection,
        Guid id)
    {
        return collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }
}
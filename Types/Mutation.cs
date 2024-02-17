using CustomerAPIGraphQL.Model;
using HotChocolate;
using MongoDB.Driver;

namespace CustomerAPIGraphQL.Types;

public class Mutation
{
    public async Task<CreateCustomerPayload> CreateCustomerAsync(
        [Service] IMongoCollection<Customer> collection,
        CreateCustomerInput input)
    {
        var customer = new Customer()
        {
            Name = input.Name,
            Addresses = input.Addresses
        };

        await collection.InsertOneAsync(customer);

        return new CreateCustomerPayload(customer);
    }
}
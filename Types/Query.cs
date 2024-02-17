using CustomerAPIGraphQL.Model;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using MongoDB.Driver;

namespace CustomerAPIGraphQL.Types;

public class Query
{
    // public Customer GetCustomer() =>
    //     new Customer
    //     {
    //         Name = "C# in depth.",
    //         Addresses = new List<Address>()
    //         {
    //             new Address() { City = "New Mexico"}
    //         }
    //     };
    
    [UsePaging]
    [UseProjection]
    [UseSorting]
    [UseFiltering]
    public IExecutable<Customer> GetCustomers([Service] IMongoCollection<Customer> collection)
    {
        return collection.AsExecutable();
    }

    [UseFirstOrDefault]
    public IExecutable<Customer> GetCustomerById(
        [Service] IMongoCollection<Customer> collection,
        Guid id)
    {
        return collection.Find(x => x.Id == id).AsExecutable();
    }
}
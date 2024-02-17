using CustomerAPIGraphQL.Resolvers;
using HotChocolate.Types.Relay;

namespace CustomerAPIGraphQL.Model;

[Node(
    IdField = nameof(Id),
    NodeResolverType = typeof(CustomerNodeResolver),
    NodeResolver = nameof(CustomerNodeResolver.ResolveAsync))]
public class Customer
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public IReadOnlyList<Address> Addresses { get; init; }
}
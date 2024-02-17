namespace CustomerAPIGraphQL.Model;

public record CreateCustomerInput(
    string Name,
    IReadOnlyList<Address> Addresses);
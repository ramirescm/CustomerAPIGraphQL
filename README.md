# API .Net GraphQL

## Running the API

To run the API, follow these steps:

1. Run `docker-compose up` to initiate the MongoDB container.
    - This command will start a MongoDB instance using Docker.

2. Access MongoDB Express to create a database and collection:
    - Open your web browser and navigate to `http://localhost:8081`.
    - Use the MongoDB Express interface to create a database and collection as needed for your application.

3. Run the API locally:
    - Ensure that you have the necessary dependencies installed for your API project.
    - Navigate to your API project directory and run the command to start the API locally. For example:
      ```bash
      dotnet run
      ```
    - This will start your GraphQL API server locally.

4. Test the API using the provided payloads.
   - Access Banana Cake http://localhost:5008/graphql/

### Adding a Customer

To add a customer, execute the following GraphQL mutation:

```graphql
mutation {
    createCustomer(input: { name: "Alice", addresses: [{ city: "New York" }] }) {
        customer {
            name
            addresses {
                city
            }
        }
    }
}
```

### Get Customer By Id

To retrieve a customer by their ID, use the following GraphQL query:

```graphql
{
  customerById(id: "6ca102b0-8c49-45e2-89cf-34fc689d3abf") {
    name
    addresses {
      city
    }
  }
}
```

### Get All Customers

To retrieve all customers, use the following GraphQL query:

```graphql
{
  customers {
    nodes {
      id
      name
      addresses {
        city
      }
    }
  }
}
```

### Get Customers with Pagination

To retrieve all customers with pagination, use the following GraphQL query:

```
{
  customers(first: 10) {
    nodes {
      id
      name
      addresses {
        city
      }
    }
  }
}
```

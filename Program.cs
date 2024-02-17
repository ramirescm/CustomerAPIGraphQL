using CustomerAPIGraphQL.Model;
using CustomerAPIGraphQL.Types;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;

var builder = WebApplication.CreateBuilder(args);
builder
    .Services
    .AddSingleton(sp =>
    {
        const string connectionString = "mongodb://root:example@localhost:27017";
        var mongoConnectionUrl = new MongoUrl(connectionString);
        var mongoClientSettings = MongoClientSettings.FromUrl(mongoConnectionUrl);
        mongoClientSettings.ClusterConfigurator = cb =>
        {
            // This will print the executed command to the console
            cb.Subscribe<CommandStartedEvent>(e =>
            {
                Console.WriteLine($"{e.CommandName} - {e.Command.ToJson()}");
            });
        };
        var client = new MongoClient(mongoClientSettings);
        var database = client.GetDatabase("customer");
        return database.GetCollection<Customer>("customers");
    })
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddGlobalObjectIdentification()
    // Registers the filter convention of MongoDB
    .AddMongoDbFiltering()
    // Registers the sorting convention of MongoDB
    .AddMongoDbSorting()
    // Registers the projection convention of MongoDB
    .AddMongoDbProjections()
    // Registers the paging providers of MongoDB
    .AddMongoDbPagingProviders();

var app = builder.Build();

app.MapGraphQL();

app.Run();
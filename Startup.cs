[assembly: FunctionsStartup(typeof(Startup))]

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder
            .AddGraphQLFunction()
            .AddSorting()
            .AddQueryType<Query>()
            .AddType<UserType>()
            .AddTypeExtension<AddressRetriever>();
    }
}

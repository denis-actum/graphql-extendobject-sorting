namespace HotChocolate.Template.AzureFunctions;

public class Query
{
    [UseSorting]
    public IEnumerable<User> GetUsers() => new List<User>
    {
        new User { Id = 1, Name = "Name1" },
        new User { Id = 2, Name = "Name2" },
        new User { Id = 3, Name = "Name3" },
        new User { Id = 4, Name = "Name4" },
    };
}

public class User
{
    public int Id { get; set; }

    public string Name { get; set; }

    public Address Address { get; set; }
}

public class Address
{
    public string Street { get; set; }
}

public class UserType : ObjectType<User>
{
    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
    {
        descriptor.Field(x => x.Address).Resolve(x =>
        {
            var id = x.Parent<User>().Id;

            return new AddressRetriever().GetAddress(id);
        });
    }
}

public class AddressRetriever
{
    public Address GetAddress(int id) => new Address { Street = $"Street{id}" };
}

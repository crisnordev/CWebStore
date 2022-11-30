namespace CWebStore.Shared.ValueObjects;

public class City : ValueObject, IValidatable
{
    protected City() {}

    public City(string name)
    {
        Validate(name);
        if (IsValid) Name = name;
    }

    public string Name { get; private set; }
    
    public void Validate(string name)
    {
        AddNotifications(new Contract<Notification>()
            .IsNotNullOrEmpty(name, "City.Name",
                "City name must not be null or empty.")
            .IsLowerThan(2, name.Length, "City.Name",
                "City name must have between 2 and 30 characters long.")
            .IsGreaterOrEqualsThan(30, name.Length, "City.Name",
                "City name must have between 2 and 30 characters long."));
    }

    public void EditCityName(string name)
    {
        Validate(name);
        if (IsValid) Name = name;
    }

    public override string ToString() => Name;
}
namespace CWebStore.Shared.ValueObjects;

public class CityValueObject : NameBaseValueObject
{
    protected CityValueObject() {}

    public CityValueObject(string name)
    {
        Validate(name);
        if (IsValid) EditorNameBase(name);
    }
    
    public void Validate(string name)
    {
        AddNotifications(new Contract<string>()
            .IsNotNullOrEmpty(name, "CityValueObject.Name",
                "City name must not be null or empty.")
            .IsLowerThan(2, name.Length, "CityValueObject.Name",
                "City name must have between 2 and 30 characters long.")
            .IsGreaterOrEqualsThan(30, name.Length, "CityValueObject.Name",
                "City name must have between 2 and 30 characters long."));
    }

    public void EditCityName(string name)
    {
        Validate(name);
        if (IsValid) EditorNameBase(name);
    }

    public override string ToString() => Name;
}
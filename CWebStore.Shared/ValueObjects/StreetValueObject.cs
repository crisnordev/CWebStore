namespace CWebStore.Shared.ValueObjects;

public class StreetValueObject : NameBaseValueObject
{
    protected StreetValueObject() {}

    public StreetValueObject(string name)
    {
        Validate(name);
        if (IsValid) EditorNameBase(name);
    }
    
    public void Validate(string name)
    {
        AddNotifications(new Contract<string>()
            .IsNotNullOrEmpty(name, "StreetValueObject.Name",
                "Street name must not be null or empty.")
            .IsLowerThan(2, name.Length, "StreetValueObject.Name",
                "Street name must have between 2 and 120 characters long.")
            .IsGreaterOrEqualsThan(120, name.Length, "StreetValueObject.Name",
                "Street name must have between 2 and 120 characters long."));
    }

    public void EditStreet(string name)
    {
        Validate(name);
        if (IsValid) EditorNameBase(name);
    }

    public override string ToString() => Name;
}
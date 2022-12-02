namespace CWebStore.Shared.ValueObjects;

public class NeighborhoodValueObject : NameBaseValueObject
{
    protected NeighborhoodValueObject() {}

    public NeighborhoodValueObject(string name)
    {
        Validate(name);
        if (IsValid) EditorNameBase(name);
    }

    public void Validate(string name)
    {
        AddNotifications(new Contract<string>()
            .IsNotNullOrEmpty(name, "NeighborhoodValueObject.Name",
                "Neighborhood name must not be null or empty.")
            .IsLowerThan(2, name.Length, "NeighborhoodValueObject.Name",
                "Neighborhood name must have between 2 and 30 characters long.")
            .IsGreaterOrEqualsThan(30, name.Length, "NeighborhoodValueObject.Name",
                "Neighborhood name must have between 2 and 30 characters long."));
    }

    public void EditNeighborhoodName(string name)
    {
        Validate(name);
        if (IsValid) EditorNameBase(name);
    }

    public override string ToString() => Name;
}
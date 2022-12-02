namespace CWebStore.Shared.ValueObjects;

public class StateValueObject : NameBaseValueObject
{
    protected StateValueObject() {}

    public StateValueObject(string name)
    {
        Validate(name);
        if (IsValid) EditorNameBase(name);
    }

    public void Validate(string name)
    {
        AddNotifications(new Contract<Notification>()
            .IsNotNullOrEmpty(name, "StateValueObject.Name",
                "State name must not be null or empty.")
            .IsLowerThan(2, name.Length, "StateValueObject.Name",
                "State name must have between 2 and 20 characters long.")
            .IsGreaterOrEqualsThan(20, name.Length, "StateValueObject.Name",
                "State name must have between 2 and 20 characters long."));
    }

    public void EditStateName(string name)
    {
        Validate(name);
        if (IsValid) EditorNameBase(name);
    }

    public override string ToString() => Name;
}
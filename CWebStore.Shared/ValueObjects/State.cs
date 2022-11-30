namespace CWebStore.Shared.ValueObjects;

public class State : ValueObject, IValidatable
{
    protected State() {}

    public State(string name)
    {
        Validate(name);
        if (IsValid) Name = name;
    }

    public string Name { get; private set; }
    
    public void Validate(string name)
    {
        AddNotifications(new Contract<Notification>()
            .IsNotNullOrEmpty(name, "State.Name",
                "State name must not be null or empty.")
            .IsLowerThan(2, name.Length, "State.Name",
                "State name must have between 2 and 20 characters long.")
            .IsGreaterOrEqualsThan(20, name.Length, "State.Name",
                "State name must have between 2 and 20 characters long."));
    }

    public void EditStateName(string name)
    {
        Validate(name);
        if (IsValid) Name = name;
    }

    public override string ToString() => Name;
}
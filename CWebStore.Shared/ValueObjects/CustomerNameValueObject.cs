namespace CWebStore.Shared.ValueObjects;

public class PersonNameValueObject : NameBaseValueObject
{
    protected  PersonNameValueObject() {}
    
    public PersonNameValueObject(string name)
    {
        Validate(name);
        if (IsValid) EditorNameBase(name);
    }

    public void Validate(string name)
    {
        AddNotifications(new Contract<string>()
            .IsNotNullOrEmpty(name, "PersonNameValueObject.Name",
                "Name must not be null or empty.")
            .IsLowerThan(2, name.Length, "PersonNameValueObject.Name",
                "Name must have between 2 and 120 characters long.")
            .IsGreaterOrEqualsThan(120, name.Length, "PersonNameValueObject.Name",
                "Name must have between 2 and 120 characters long."));
    }

    public void EditPersonName(string name)
    {
        Validate(name);
        if (IsValid) EditorNameBase(name);
    }

    public override string ToString() => Name;
}
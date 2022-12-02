namespace CWebStore.Shared.ValueObjects;

public class CategoryNameValueObject : NameBaseValueObject
{
    protected CategoryNameValueObject()
    {
    }
    
    public CategoryNameValueObject(string name)
    {
        Validate(name);
        if (IsValid) EditorNameBase(name);
    }

    public void Validate(string name)
    {
        AddNotifications(new Contract<string>()
            .IsNotNullOrEmpty(name, "CategoryNameValueObject.Name",
                "Category name must not be null or empty.")
            .IsLowerThan(2, name.Length, "CategoryNameValueObject.Name",
                "Category name must have between 2 and 60 characters long.")
            .IsGreaterOrEqualsThan(60, name.Length, "CategoryNameValueObject.Name",
                "Category name must have between 2 and 60 characters long."));
    }

    public void EditCategoryName(string name)
    {
        Validate(name);
        if (IsValid) EditorNameBase(name);
    }

    public override string ToString() => Name;
}
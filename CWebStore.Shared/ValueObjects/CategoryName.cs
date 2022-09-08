namespace CWebStore.Shared.ValueObjects;

public class CategoryName : ValueObject, IValidatable
{
    protected  CategoryName() {}
    
    public CategoryName(string name)
    {
        Validate(name);
        
        if (IsValid)
            Name = name;
    }

    public string Name { get; private set; }

    public void Validate(string name)
    {
        AddNotifications(new Contract<Notification>()
            .IsNotNullOrEmpty(name, "CategoryName.Name",
                "Category name must not be null or empty.")
            .IsLowerThan(2, name.Length, "CategoryName.Name",
                "Category name must have two or more characters.")
            .IsGreaterOrEqualsThan(80, name.Length, "CategoryName.Name",
                "Category name must have 80 or less characters."));
    }

    public void EditCategoryName(string name)
    {
        Validate(name);
        
        if (IsValid)
            Name = name;
    }

    public override string ToString() => Name;
}
namespace CWebStore.Shared.ProductValueObjects.ValueObjects;

public class CategoryName : ValueObject, IValidatable
{
    protected  CategoryName() {}
    
    public CategoryName(string name)
    {
        Name = name;
        Validate();
    }

    public string Name { get; private set; }

    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .IsNotNullOrEmpty(Name, "CategoryName.Name",
                "Category name must not be null or empty.")
            .IsLowerThan(2, Name.Length, "CategoryName.Name",
                "Category name must have two or more characters.")
            .IsGreaterOrEqualsThan(80, Name.Length, "CategoryName.Name",
                "Category name must have 80 or less characters."));
    }

    public void EditCategoryName(string name)
    {
        Name = name;
        Validate();
    }

    public override string ToString() => Name;
}
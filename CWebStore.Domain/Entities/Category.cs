namespace CWebStore.Domain.Entities;

public class Category : Entity
{
    private readonly IList<Product> _products;
    protected Category() { }

    public Category(string name)
    {
        var categoryName = new CategoryNameValueObject(name);
        Validate(categoryName);
        Name = categoryName;
        _products = new List<Product>();
    }

    public CategoryNameValueObject Name { get; private set; }

    public IReadOnlyCollection<Product> Products => _products.ToArray();

    public void Validate(CategoryNameValueObject categoryName)
    {
        AddNotifications(categoryName);
    }
    
    public void EditCategoryName(string name)
    {
        Name.EditCategoryName(name);
        
        if (!Name.IsValid)
            AddNotifications(Name);
    }
}
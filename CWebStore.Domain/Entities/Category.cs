namespace CWebStore.Domain.Entities;

public class Category : Entity, IValidatable
{
    private IList<Product> _products;
    protected Category() { }

    public Category(CategoryName name)
    {
        CategoryName = name;
        _products = new List<Product>();
        Validate();
    }

    public CategoryName CategoryName { get; private set; }

    public IReadOnlyCollection<Product>? Products => _products.ToArray();

    public void Validate()
    {
        AddNotifications(CategoryName);

        foreach (var product in Products)
            AddNotifications(product);
    }
    
    public void EditCategoryName(string name)
    {
        CategoryName.EditCategoryName(name);
        
        if (!CategoryName.IsValid)
            AddNotifications(CategoryName);
    }
}
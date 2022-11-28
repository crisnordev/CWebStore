namespace CWebStore.Domain.Entities;

public class Category : Entity, IValidatable
{
    private IList<Product> _products;
    protected Category() { }

    public Category(string name)
    {
        Name = new CategoryName(name);
        _products = new List<Product>();
        Validate();
    }

    public CategoryName Name { get; private set; }

    public IReadOnlyCollection<Product> Products => _products.ToArray();

    public void Validate()
    {
        AddNotifications(Name);

        foreach (var product in Products)
            AddNotifications(product);
    }
    
    public void EditCategoryName(string name)
    {
        Name.EditCategoryName(name);
        
        if (!Name.IsValid)
            AddNotifications(Name);
    }
}
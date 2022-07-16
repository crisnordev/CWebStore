namespace CWebStore.Domain.Entities;

public class Category : Entity, IValidatable
{
    private IList<Product> _products;

    protected Category()
    {
    }

    public Category(CategoryName name)
    {
        AddNotifications(name);

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
    
    public void EditCategoryName(CategoryName name)
    {
        name.Validate();

        if (!name.IsValid)
            AddNotifications(name);

        else
            CategoryName = name;

    }

    public void AddProduct(Product product)
    {
        product.Validate();
        
        if (!product.IsValid)
            AddNotifications(product);

        else if (_products.Any(x => x.Id == product.Id))
            AddNotification("Category.Products", "This product has already been added.");

        else
            _products.Add(product);

        Validate();
    }

    public void RemoveProduct(Product product)
    {
        product.Validate();
        
        if (!product.IsValid)
            AddNotifications(product);
        
        else if (_products.All(x => x.Id != product.Id))
            AddNotification("Category.Products", "Can not find this product.");

        else
            _products.Remove(product);
    }
}
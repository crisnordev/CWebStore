using CWebStore.Shared.ProductValueObjects.ValueObjects;

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

    public void AddProduct(Product product)
    {
        if (!product.IsValid)
            AddNotification("Category.Products", "It is not possible to add this product.");

        else if (_products.Any(x => x.Id == product.Id))
            AddNotification("Category.Products", "This product has already been added.");

        else
            _products.Add(product);

        Validate();
    }

    public void EditCategoryName(string categoryName)
    {
        CategoryName.EditCategoryName(categoryName);

        Validate();
    }

    public void RemoveProduct(Product product)
    {
        if (!product.IsValid || _products.All(x => x.Id != product.Id))
            AddNotification("Category.Products", "It is not possible to remove this product.");

        else
            _products.Remove(product);

        Validate();
    }
}
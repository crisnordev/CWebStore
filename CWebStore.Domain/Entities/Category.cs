namespace CWebStore.Domain.Entities;

public class Category : Entity, IValidatable
{
    private IList<Product> _products;

    protected Category() { }

    public Category(string name)
    {
        _products = new List<Product>();
        
        var categoryName = new CategoryName(name);
        Validate(categoryName);
        if (!IsValid) return;
        
        CategoryName = categoryName;
    }

    public CategoryName CategoryName { get; private set; }

    public IReadOnlyCollection<Product> Products => _products.ToArray();

    public void Validate(CategoryName categoryName) => AddNotifications(categoryName);
    
    
    public void EditCategoryName(string name)
    {
        CategoryName.EditCategoryName(name);
        AddNotifications(CategoryName);
    }

    public override string ToString() => CategoryName.Name;
}
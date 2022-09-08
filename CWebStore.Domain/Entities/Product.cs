namespace CWebStore.Domain.Entities;

public class Product : Entity, IValidatable
{
    private IList<Category> _categories;

    protected Product() { }

    public Product(string productName, decimal sellPrice, int stockQuantity)
    {
        _categories = new List<Category>();
        
        var name = new ProductName(productName);
        var price = new Price(sellPrice);
        var quantity = new Quantity(stockQuantity);
        Validate(name, price, quantity);
        if (!IsValid) return;

        ProductName = name;
        Price = price;
        StockQuantity = quantity;
    }
    
    public ProductName ProductName { get; private set; }

    public Price Price { get; private set; }

    public Quantity StockQuantity { get; private set; }

    public Description Description { get; private set; }

    public Manufacturer Manufacturer { get; private set; }

    public FileName ImageFileName { get; private set; }

    public UrlString ImageUrl { get; private set; }

    public IReadOnlyCollection<Category> Categories => _categories.ToArray();

    public void Validate(ProductName productName, Price sellPrice, Quantity stockQuantity) =>
        AddNotifications(productName, sellPrice, stockQuantity);

    public void AddCategory(Category category)
    {
        AddNotifications(new Contract<Product>()
            .IsFalse(Categories.All(x => x != category), "Product.AddCategory", 
                "This product already has this category.").Join(category));
        if (!IsValid) return;
        
        _categories.Add(category);
    }

    public void RemoveCategory(Guid categoryId)
    {
        var category = Categories.FirstOrDefault(x => x.Id == categoryId);
        AddNotifications(new Contract<Product>()
            .IsNullOrEmpty(category.CategoryName.ToString(), "Product.RemoveCategory", 
                "This product does not have this category in list."));
        
        if (IsValid)
            _categories.Remove(category);
    }

    public void EditProductName(string name)
    {
        ProductName.EditProductName(name);
        AddNotifications(ProductName);
    }
    
    public void EditProductSellValue(decimal sellValue)
    {
        Price.EditSellValue(sellValue);
        AddNotifications(Price);
    }
    
    public void EditProductBuyValue(decimal buyValue)
    {
        Price.EditBuyValue(buyValue);
        AddNotifications(Price);
    }
    
    public void EditProductPercentage(decimal percentage)
    {
        Price.EditPercentage(percentage);
        AddNotifications(Price);
    }
    
    
    public void EditProductStockQuantity(int quantity)
    {
        StockQuantity.EditQuantityValue(quantity);
        AddNotifications(StockQuantity);
    }

    public void EditProductDescription(string description)
    {
        Description.EditDescriptionText(description);
        AddNotifications(Description);

    }

    public void EditProductManufacturer(string manufacturer)
    {
        Manufacturer.EditManufacturerName(manufacturer);
        AddNotifications(Manufacturer);
    }

    public void EditProductFileName(string fileName)
    {
        ImageFileName.EditFileName(fileName);
        AddNotifications(ImageFileName);
    }

    public void EditProductUrl(string url)
    {
        ImageUrl.EditUrlPropertyString(url);
        AddNotifications(ImageUrl);
    }
}
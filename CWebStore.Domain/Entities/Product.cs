namespace CWebStore.Domain.Entities;

public class Product : Entity, IValidatable
{
    private IList<Category> _categories;

    protected Product()
    {
        _categories = new List<Category>();
    }

    public Product(string productName, decimal sellPrice, int stockQuantity)
    {
        _categories = new List<Category>();
        
        var name = new ProductName(productName);
        var price = new Price(sellPrice);
        var quantity = new Quantity(stockQuantity);
        Validate(name, price, quantity);

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

    public void Validate(Category category) =>
        AddNotifications(category);

    public void AddCategory(Category category)
    {
        Validate(category);

        if (!IsValid)
            AddNotification("Product.AddCategory", "This is not a valid category.");

        _categories.Add(category);
    }

    public void RemoveCategory(Guid id)
    {
        var category = _categories.FirstOrDefault(x => x.Id == id);
        AddNotifications(new Contract<Product>()
            .IsNotEmpty(id, "Product.RemoveCategory", "This id can not be null or empty.")
            .AreEquals(category.Id, id, "Product.RemoveCategory", 
                "Can not find this category."));
        if (!IsValid) return;
        
        _categories.Remove(_categories.First(x => x.Id == id));
    }

    public void EditProductName(string name)
    {
        ProductName.EditProductName(name);
        
        if (!ProductName.IsValid)
            AddNotifications(ProductName);
    }
    
    public void EditProductSellValue(decimal sellValue)
    {
        Price.EditSellValue(sellValue);
        
        if (!Price.IsValid)
            AddNotifications(Price);
    }
    
    public void EditProductBuyValue(decimal buyValue)
    {
        Price.EditBuyValue(buyValue);
        
        if (!Price.IsValid)
            AddNotifications(Price);
    }
    
    public void EditProductPercentage(decimal percentage)
    {
        Price.EditPercentage(percentage);
        
        if (!Price.IsValid)
            AddNotifications(Price);
    }
    
    
    public void EditProductStockQuantity(int quantity)
    {
        StockQuantity.EditQuantityValue(quantity);
        
        if (!StockQuantity.IsValid)
            AddNotifications(StockQuantity);
    }

    public void EditProductDescription(string description)
    {
        Description.EditDescriptionText(description);
        
        if (!Description.IsValid)
            AddNotifications(Description);

    }

    public void EditProductManufacturer(string manufacturer)
    {
        Manufacturer.EditManufacturerName(manufacturer);
        
        if (!Manufacturer.IsValid)
            AddNotifications(Manufacturer);
    }

    public void EditProductFileName(string fileName)
    {
        ImageFileName.EditFileName(fileName);
        
        if (!ImageFileName.IsValid)
            AddNotifications(ImageFileName);
    }

    public void EditProductUrl(string url)
    {
        ImageUrl.EditUrlPropertyString(url);
        
        if (!ImageUrl.IsValid)
            AddNotifications(ImageUrl);
    }
}
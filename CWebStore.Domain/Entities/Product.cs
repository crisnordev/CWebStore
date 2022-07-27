namespace CWebStore.Domain.Entities;

public class Product : Entity, IValidatable
{
    private IList<Category> _categories;

    protected Product() { }

    public Product(ProductName productName, Price price, Quantity stockQuantity)
    {
        ProductName = productName;
        Price = price;
        StockQuantity = stockQuantity;
        _categories = new List<Category>();
        Validate();
    }

    public Product(ProductName productName, Price price, Quantity stockQuantity, Description description,
        Manufacturer manufacturer, FileName imageFileName, UrlString imageUrl)
    {
        ProductName = productName;
        Price = price;
        StockQuantity = stockQuantity;
        Description = description;
        Manufacturer = manufacturer;
        ImageFileName = imageFileName;
        ImageUrl = imageUrl;
        _categories = new List<Category>();
        Validate();
    }

    public ProductName ProductName { get; private set; }

    public Price Price { get; private set; }

    public Quantity StockQuantity { get; private set; }

    public Description Description { get; private set; }

    public Manufacturer Manufacturer { get; private set; }

    public FileName ImageFileName { get; private set; }

    public UrlString ImageUrl { get; private set; }

    public IReadOnlyCollection<Category> Categories => _categories.ToArray();

    public void Validate()
    {
        AddNotifications(ProductName, Description, Manufacturer, StockQuantity, Price,
            ImageFileName, ImageUrl);

        foreach (var category in Categories)
            AddNotifications(category);
    }

    public void AddCategory(Category category)
    {
        category.Validate();

        if (!category.IsValid)
            AddNotification("Product.AddCategory", "Can not add this category.");

        if (_categories.Any(x => x.Id == category.Id))
            AddNotification("Product.Categories", "This category has already been added.");

        _categories.Add(category);
    }

    public void RemoveCategory(Guid id)
    {
        if (id == null || id == Guid.Empty)
            AddNotification("Product.Categories", "This id can not be null or empty.");
        
        else if (_categories.All(x => x.Id != id))
            AddNotification("Product.Categories", "Can not find this category.");

        else
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
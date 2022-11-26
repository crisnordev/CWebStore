namespace CWebStore.Domain.Entities;

public class Product : Entity, IValidatable
{
    protected Product() { }

    public Product(ProductName productName, Price price, Quantity stockQuantity)
    {
        Name = productName;
        Price = price;
        StockQuantity = stockQuantity;
        Validate();
    }

    public Product(ProductName productName, Price price, Quantity stockQuantity, Description description,
        Manufacturer manufacturer, FileName imageFileName, UrlString imageUrl)
    {
        Name = productName;
        Price = price;
        StockQuantity = stockQuantity;
        Description = description;
        Manufacturer = manufacturer;
        ImageFileName = imageFileName;
        ImageUrl = imageUrl;
        Validate();
    }

    public ProductName Name { get; private set; }

    public Price Price { get; private set; }

    public string Code { get; set; }

    public string BarCode { get; set; }

    public Quantity StockQuantity { get; private set; }

    public string NcmCode { get; set; }

    public string CestCode { get; set; }

    public decimal NetWeight { get; set; }

    public decimal GrossWeight { get; set; }

    public Guid CategoryId { get; set; }

    public Category Category { get; set; }

    public string UnitMeasure { get; set; }

    public IList<Guid> SuppliersId { get; set; }

    public Description Description { get; private set; }

    public Manufacturer Manufacturer { get; private set; }

    public FileName ImageFileName { get; private set; }

    public UrlString ImageUrl { get; private set; }

    public void Validate()
    {
        AddNotifications(Name, Price, Description, Manufacturer, StockQuantity, Category, ImageFileName, ImageUrl);
    }

    public void EditCategory(Category category)
    {
        category.Validate();

        if (!category.IsValid)
            AddNotification("Product.EditCategory", "Can not add this category.");

        Category = category;
    }

    public void EditProductName(string name)
    {
        Name.EditProductName(name);
        
        if (!Name.IsValid)
            AddNotifications(Name);
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
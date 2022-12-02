namespace CWebStore.Domain.Entities;

public class Product : Entity, IValidatable
{
    protected Product() { }

    public Product(string id, string name, decimal value, int stockQuantity) : base(id)
    {
        Name = new ProductNameValueObject(name);
        Price = new PriceValueObject(value);
        StockQuantity = new QuantityValueObject(stockQuantity);
        Validate();
    }

    public ProductNameValueObject Name { get; private set; }

    public PriceValueObject Price { get; private set; }

    public ProductCodeValueObject Code { get; private set; }

    public QuantityValueObject StockQuantity { get; private set; }

    public decimal NetWeight { get; private set; }

    public decimal GrossWeight { get; private set; }

    public Guid CategoryId { get; private set; }

    public Category Category { get; private set; }

    public string UnitMeasure { get; private set; }

    public FileNameValueObject ImageFileName { get; private set; }

    public UrlStringValueObject ImageUrl { get; private set; }

    public void Validate()
    {
        AddNotifications(Name, Price, StockQuantity);
    }

    public void EditCategory(Category category)
    {
        if (category.IsValid) Category = category;
        AddNotification("Product.EditCategory", "Can not add this category.");
    }

    public void EditProductName(string name)
    {
        Name.EditProductName(name);
        
        if (!Name.IsValid)
            AddNotifications(Name);
    }
    
    public void EditProductValue(decimal value)
    {
        Price.EditValue(value);
        
        if (!Price.IsValid)
            AddNotifications(Price);
    }
    
    public void EditProductCost(decimal cost)
    {
        Price.EditCost(cost);
        
        if (!Price.IsValid)
            AddNotifications(Price);
    }

    public void EditProductStockQuantity(int quantity)
    {
        StockQuantity.EditQuantityValue(quantity);
        
        if (!StockQuantity.IsValid)
            AddNotifications(StockQuantity);
    }

    public void EditProductFileName(string fileName)
    {
        ImageFileName.EditFileName(fileName);
        
        if (!ImageFileName.IsValid)
            AddNotifications(ImageFileName);
    }

    public void EditProductUrl(string url)
    {
        ImageUrl.EditUrl(url);
        
        if (!ImageUrl.IsValid)
            AddNotifications(ImageUrl);
    }
}
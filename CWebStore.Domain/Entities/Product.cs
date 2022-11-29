namespace CWebStore.Domain.Entities;

public class Product : Entity, IValidatable
{
    protected Product() { }

    public Product(string id, string name, decimal value, int stockQuantity)
    {
        Id = new Guid(id);
        Name = new ProductName(name);
        Price = new Price(value);
        StockQuantity = new Quantity(stockQuantity);
        Validate();
    }

    public sealed override Guid Id { get; protected set; }

    public ProductName Name { get; private set; }

    public Price Price { get; private set; }

    public string Code { get; set; }

    public Quantity StockQuantity { get; private set; }

    public decimal NetWeight { get; set; }

    public decimal GrossWeight { get; set; }

    public Guid CategoryId { get; set; }

    public Category Category { get; set; }

    public string UnitMeasure { get; set; }

    public FileName ImageFileName { get; private set; }

    public UrlString ImageUrl { get; private set; }

    public void Validate()
    {
        AddNotifications(new Contract<string>()
            .IsNotNullOrEmpty(Id.ToString(), "Product.Id",
                "Product Id must not be null or empty.")
            .AreEquals(Id, Guid.Empty, "Product.Id",
                "Product Id must not be null or empty.")
            .Join(Name, Price, StockQuantity));
    }

    public void EditCategory(Category category)
    {
        category.Validate();
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
        ImageUrl.EditUrlPropertyString(url);
        
        if (!ImageUrl.IsValid)
            AddNotifications(ImageUrl);
    }
}
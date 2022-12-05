using CWebStore.Shared.Enums;

namespace CWebStore.Domain.Entities;

public class Product : Entity, IValidatable
{
    protected Product() { }

    public Product(string id, string name, decimal value) : base(id)
    {
        Name = new ProductNameValueObject(name);
        Price = new PriceValueObject(value);
        Validate();
    }
    
    public Product(string id, string name, decimal value, decimal cost, string code, int availableStock, 
        string unitMeasure, string imageFileName, string imageUrl, string categoryId, string categoryName) 
        : base(id)
    {
        Name = new ProductNameValueObject(name);
        Price = new PriceValueObject(value, cost);
        AvailableStock = new AvailableStockValueObject(availableStock);
        Code = new ProductCodeValueObject(code);
        UnitMeasure = unitMeasure;
        ImageFileName = new FileNameValueObject(imageFileName);
        ImageUrl = new UrlStringValueObject(imageUrl);
        CategoryId = new Guid(categoryId);
        Category = new Category(categoryId, categoryName);
    }

    public ProductNameValueObject Name { get; private set; }

    public PriceValueObject Price { get; private set; }

    public ProductCodeValueObject Code { get; private set; }

    public AvailableStockValueObject AvailableStock { get; private set; }

    public decimal NetWeight { get; private set; }

    public decimal GrossWeight { get; private set; }

    public Guid CategoryId { get; private set; }

    public Category Category { get; private set; }

    public string UnitMeasure { get; private set; }

    public FileNameValueObject ImageFileName { get; private set; }

    public UrlStringValueObject ImageUrl { get; private set; }

    public void Validate()
    {
        AddNotifications(Name, Price, Code, AvailableStock, Category, ImageFileName, ImageUrl);
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

    public void EditProductAvailableStock(int quantity)
    {
        AvailableStock.EditQuantityValue(quantity);
        
        if (!AvailableStock.IsValid)
            AddNotifications(AvailableStock);
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
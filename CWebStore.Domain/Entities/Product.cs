namespace CWebStore.Domain.Entities;

public class Product : Entity, IValidatable
{
    private IList<Category> _categories;

    protected Product() { }

    public Product(ProductName productName, Price price, Quantity stockQuantity)
    {
        AddNotifications(productName, price, stockQuantity);

        ProductName = productName;
        Price = price;
        StockQuantity = stockQuantity;
        _categories = new List<Category>();
        Validate();
    }

    public Product(ProductName productName, Price price, Quantity stockQuantity, ProductDescription description,
        Manufacturer manufacturer, FileName imageFileName, UrlString imageUrl)
    {
        AddNotifications(productName, price, stockQuantity, description, manufacturer,
            imageFileName, imageUrl);

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

    public ProductDescription Description { get; private set; }

    public Manufacturer Manufacturer { get; private set; }

    public Quantity StockQuantity { get; private set; }

    public Price Price { get; private set; }

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
            AddNotifications(category);

        else if (_categories.Any(x => x.Id == category.Id))
            AddNotification("Product.Categories", "This category has already been added.");

        else
            _categories.Add(category);
    }
    
    public void RemoveCategory(Category category)
    {
        category.Validate();
        
        if (!category.IsValid)
            AddNotifications(category);

        else if (_categories.All(x => x.Id != category.Id))
            AddNotification("Product.Categories", "Can not find this category.");

        else
            _categories.Add(category);
    }

    public void EditProductName(ProductName name)
    {
        name.Validate();
        
        if (!name.IsValid)
            AddNotifications(name);

        else
            ProductName = name;
    }

    public void EditProductPrice(Price price)
    {
        price.Validate();
        
        if (!price.IsValid)
            AddNotifications(price);

        else
            Price = price;
    }

    public void EditProductStockQuantity(Quantity quantity)
    {
        quantity.Validate();
        
        if (!quantity.IsValid)
            AddNotifications(quantity);

        else
            StockQuantity = quantity;
    }

    public void EditProductDescription(ProductDescription description)
    {
        description.Validate();
        
        if (!description.IsValid)
            AddNotifications(description);

        else
            Description = description;
    }

    public void EditProductManufacturer(Manufacturer manufacturer)
    {
        manufacturer.Validate();
        
        if (!manufacturer.IsValid)
            AddNotifications(manufacturer);

        else
            Manufacturer = manufacturer;
    }

    public void EditProductImage(FileName fileName, UrlString url)
    {
        fileName.Validate();
        url.Validate();
        
        if (!fileName.IsValid || !url.IsValid)
            AddNotifications(fileName, url);

        else
        {
            ImageFileName = fileName;
            ImageUrl = url;
        }
    }
}
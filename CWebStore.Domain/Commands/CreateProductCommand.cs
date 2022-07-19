namespace CWebStore.Domain.Commands;

public class CreateProductCommand : Notifiable<Notification>, ICommand
{
    public CreateProductCommand() { }

    public CreateProductCommand(string productName, string productDescription, string manufacturerName, decimal sellValue, int stockQuantity, string imageFileName, string imageUrl)
    {
        ProductName = productName;
        ProductDescription = productDescription;
        ManufacturerName = manufacturerName;
        SellValue = sellValue;
        StockQuantity = stockQuantity;
        ImageFileName = imageFileName;
        ImageUrl = imageUrl;
        Validate();
    }

    public CreateProductCommand(string productName, string productDescription, string manufacturerName, decimal buyValue, decimal percentage, int stockQuantity, string imageFileName, string imageUrl)
    {
        ProductName = productName;
        ProductDescription = productDescription;
        ManufacturerName = manufacturerName;
        SellValue = buyValue + buyValue * percentage;
        BuyValue = buyValue;
        Percentage = percentage;
        StockQuantity = stockQuantity;
        ImageFileName = imageFileName;
        ImageUrl = imageUrl;
        Validate();
    }

    public CreateProductCommand(string productName, string productDescription, string manufacturerName, decimal sellValue, decimal buyValue, decimal percentage, int stockQuantity, string imageFileName, string imageUrl)
    {
        ProductName = productName;
        ProductDescription = productDescription;
        ManufacturerName = manufacturerName;
        SellValue = sellValue;
        BuyValue = buyValue;
        Percentage = percentage;
        StockQuantity = stockQuantity;
        ImageFileName = imageFileName;
        ImageUrl = imageUrl;
        Validate();
    }

    public string ProductName { get; set; }
    
    public string ProductDescription { get; set; }
    
    public string ManufacturerName { get; set; }
    
    public decimal SellValue { get; private set; }

    public decimal BuyValue { get; private set; }

    public decimal Percentage { get; private set; }
    
    public int StockQuantity { get; set; }
    
    public string ImageFileName { get; set; }

    public string ImageUrl { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<string>()
            .IsNotNullOrEmpty(ProductName, "CreateProductCommand.ProductName",
                "Product name must not be null or empty.")
            .IsLowerThan(2, ProductName.Length, "CreateProductCommand.ProductName",
                "Product name must have two or more characters.")
            .IsGreaterThan(120, ProductName.Length, "CreateProductCommand.ProductName",
                "Product name must have 120 or less characters.")
            .IsNotNullOrEmpty(ProductDescription, "CreateProductCommand.ProductDescription",
                "Product description must not be null or empty.")
            .IsLowerThan(2, ProductDescription.Length, "CreateProductCommand.ProductDescription",
                "Product description must have two or more characters.")
            .IsGreaterThan(160, ProductDescription.Length, "CreateProductCommand.ProductDescription",
                "Product description must have 160 or less characters.")
            .IsNotNullOrEmpty(ManufacturerName, "CreateProductCommand.ManufacturerName",
                "Manufacturer name must not be null or empty.")
            .IsLowerThan(2, ManufacturerName.Length, "CreateProductCommand.ManufacturerName",
                "Manufacturer name must have two or more characters.")
            .IsGreaterOrEqualsThan(120, ManufacturerName.Length, "CreateProductCommand.ManufacturerName",
                "Manufacturer name must have 120 or less characters.")
            .IsNotNullOrEmpty(ImageFileName, "CreateProductCommand.ImageFileName",
                "File name must not be null or empty.")
            .IsLowerThan(6, ImageFileName.Length, "CreateProductCommand.ImageFileName",
                "File name must have two or more characters.")
            .IsGreaterThan(60, ImageFileName.Length, "CreateProductCommand.ImageFileName",
                "File name must have 60 or less characters.")
            .IsGreaterThan(2048, ImageUrl.Length, "CreateProductCommand.ImageUrl",
                "Url must have 2048 or less characters.")
            .IsUrlOrEmpty(ImageUrl, "CreateProductCommand.ImageUrl",
                "This is not a valid Url.")
            .IsUrl(ImageUrl, "CreateProductCommand.ImageUrl",
                "This is not a valid Url."));
        
        AddNotifications(new Contract<decimal>()
            .IsGreaterThan(SellValue, 0m, "CreateProductCommand.SellValue",
                "This value must not be lower or equals 0.")
            .IsLowerThan(SellValue, 200000m, "CreateProductCommand.SellValue",
                "This value must not be greater than 200000.")
            .IsGreaterOrEqualsThan(BuyValue, 0m, "CreateProductCommand.BuyValue",
                "This value must not be lower than 0.")
            .IsLowerThan(BuyValue, 100000m, "CreateProductCommand.BuyValue",
                "This value must not be greater than 100000.")
            .IsGreaterOrEqualsThan(Percentage, 0m, "CreateProductCommand.Percentage",
                "Percentage must not be lower than 0.")
            .IsLowerThan(Percentage, 100m, "CreateProductCommand.Percentage",
                "Percentage must not be greater than 100.")
            .IsLowerThan(0, StockQuantity, "CreateProductCommand.StockQuantity",
                "Quantity must not be lower or equals 0.")
            .IsGreaterThan(1000000, StockQuantity, "CreateProductCommand.StockQuantity",
                "Quantity must not be greater than 1000000"));

        if (BuyValue > 0)
        {
            AddNotifications(new Contract<decimal>()
                .AreEquals(SellValue, BuyValue + BuyValue * Percentage, "CreateProductCommand.StockQuantity", 
                    $"Sell value must be {Percentage}% greater than buy value"));
        }
    }
}
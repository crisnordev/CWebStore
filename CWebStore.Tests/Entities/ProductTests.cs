namespace CWebStore.Tests.Entities;

[TestClass]
public class ProductTests
{
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_product_with_invalid_name_should_return_error_message()
    {
        var product = new Product(new ProductName(string.Empty), new Price(1), new Quantity(1), 
            new Description("Product description"), new Manufacturer("Manufacturer"), 
            new FileName("fileName.png"), new UrlString("https://balta.io/"));
        var message = "Product name must not be null or empty.";
        Assert.AreEqual(message, product.Notifications.FirstOrDefault().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_AddCategory_with_invalid_category_should_return_error_message()
    {
        var product = new Product(new ProductName("Product name"), new Price(1), new Quantity(1), 
            new Description("Product description"), new Manufacturer("Manufacturer"), 
            new FileName("fileName.png"), new UrlString("https://balta.io/"));
        product.AddCategory(new Category(new CategoryName(string.Empty)));
        var message = "Category name must not be null or empty.";
        Assert.AreEqual(message, product.Notifications.FirstOrDefault().Message);
    }
    
    
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductName_with_invalid_name_should_return_error_message()
    {
        var product = new Product(new ProductName("Product name"), new Price(1), new Quantity(1), 
            new Description("Product description"), new Manufacturer("Manufacturer"), 
            new FileName("fileName.png"), new UrlString("https://balta.io/"));
        product.EditProductName(new ProductName(string.Empty));
        var message = "Product name must not be null or empty.";
        Assert.AreEqual(message, product.Notifications.FirstOrDefault().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductSellPrice_with_invalid_price_should_return_error_message()
    {
        var product = new Product(new ProductName("Product name"), new Price(1), new Quantity(1),
            new Description("Product description"), new Manufacturer("Manufacturer"),
            new FileName("fileName.png"), new UrlString("https://balta.io/"));
        product.Price.EditSellValue(-1);
        product.EditProductPrice(product.Price);
        var message = "Sell value must not be lower than 0.";
        Assert.AreEqual(message, product.Notifications.FirstOrDefault().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductBuyPrice_with_invalid_price_should_return_error_message()
    {
        var product = new Product(new ProductName("Product name"), new Price(1), new Quantity(1),
            new Description("Product description"), new Manufacturer("Manufacturer"),
            new FileName("fileName.png"), new UrlString("https://balta.io/"));
        product.Price.EditBuyValue(-1);
        product.EditProductPrice(product.Price);
        var message = "Buy value must not be lower than 0.";
        Assert.AreEqual(message, product.Notifications.FirstOrDefault().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.ValueObjects")]
    public void Given_a_product_EditProductPercentage_with_invalid_value_should_return_error_message()
    {
        var product = new Product(new ProductName("Product name"), new Price(1), new Quantity(1),
            new Description("Product description"), new Manufacturer("Manufacturer"),
            new FileName("fileName.png"), new UrlString("https://balta.io/"));
        product.Price.EditPercentage(-1);
        product.EditProductPrice(product.Price);
        var message = "Percentage must not be lower than 0.";
        Assert.AreEqual(message, product.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductStockQuantity_with_invalid_value_should_return_error_message()
    {
        var product = new Product(new ProductName("Product name"), new Price(1), new Quantity(1), 
            new Description("Product description"), new Manufacturer("Manufacturer"), 
            new FileName("fileName.png"), new UrlString("https://balta.io/"));
        product.EditProductStockQuantity(new Quantity(-1));
        var message = "Quantity must not be lower than 0.";
        Assert.AreEqual(message, product.Notifications.FirstOrDefault().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductDescription_with_invalid_value_should_return_error_message()
    {
        var product = new Product(new ProductName("Product name"), new Price(1), new Quantity(1), 
            new Description("Product description"), new Manufacturer("Manufacturer"), 
            new FileName("fileName.png"), new UrlString("https://balta.io/"));
        product.EditProductDescription(new Description(string.Empty));
        var message = "Product description must not be null or empty.";
        Assert.AreEqual(message, product.Notifications.FirstOrDefault().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductManufacturer_with_invalid_value_should_return_error_message()
    {
        var product = new Product(new ProductName("Product name"), new Price(1), new Quantity(1), 
            new Description("Product description"), new Manufacturer("Manufacturer"), 
            new FileName("fileName.png"), new UrlString("https://balta.io/"));
        product.EditProductManufacturer(new Manufacturer(string.Empty));
        var message = "Manufacturer name must not be null or empty.";
        Assert.AreEqual(message, product.Notifications.FirstOrDefault().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductImage_with_invalid_value_should_return_error_message()
    {
        var product = new Product(new ProductName("Product name"), new Price(1), new Quantity(1), 
            new Description("Product description"), new Manufacturer("Manufacturer"), 
            new FileName("fileName.png"), new UrlString("https://balta.io/"));
        product.EditProductImageData(new FileName(string.Empty), new UrlString("https://docs.microsoft.com"));
        var message = "File name must not be null or empty.";
        Assert.AreEqual(message, product.Notifications.FirstOrDefault().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_should_return_IsValid()
    {
        var product = new Product(new ProductName("Product name"), new Price(1), new Quantity(1), 
            new Description("Product description"), new Manufacturer("Manufacturer"), 
            new FileName("fileName.png"), new UrlString("https://balta.io/"));
        Assert.IsTrue(product.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_AddCategory_with_valid_category_should_return_IsValid()
    {
        var product = new Product(new ProductName("Product name"), new Price(1), new Quantity(1), 
            new Description("Product description"), new Manufacturer("Manufacturer"), 
            new FileName("fileName.png"), new UrlString("https://balta.io/"));
        product.AddCategory(new Category(new CategoryName("Valid category")));
        Assert.IsTrue(product.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductName_with_valid_name_should_return_IsValid()
    {
        var product = new Product(new ProductName("Product name"), new Price(1), new Quantity(1), 
            new Description("Product description"), new Manufacturer("Manufacturer"), 
            new FileName("fileName.png"), new UrlString("https://balta.io/"));
        product.EditProductName(new ProductName("New product name"));
        Assert.IsTrue(product.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductSellPrice_with_valid_price_should_return_IsValid()
    {
        var product = new Product(new ProductName("Product name"), new Price(1), new Quantity(1),
            new Description("Product description"), new Manufacturer("Manufacturer"),
            new FileName("fileName.png"), new UrlString("https://balta.io/"));
        product.Price.EditSellValue(2);
        product.EditProductPrice(product.Price);
        Assert.IsTrue(product.IsValid);
    }

    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductBuyPrice_with_valid_price_should_return_IsValid()
    {
        var product = new Product(new ProductName("Product name"), new Price(1, 20), new Quantity(1),
            new Description("Product description"), new Manufacturer("Manufacturer"),
            new FileName("fileName.png"), new UrlString("https://balta.io/"));
        product.Price.EditBuyValue(2);
        product.EditProductPrice(product.Price);
        Assert.IsTrue(product.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.ValueObjects")]
    public void Given_a_product_EditProductPercentage_with_valid_value_should_return_IsValid()
    {
        var product = new Product(new ProductName("Product name"), new Price(1, 10), new Quantity(1), 
            new Description("Product description"), new Manufacturer("Manufacturer"), 
            new FileName("fileName.png"), new UrlString("https://balta.io/"));
        product.Price.EditPercentage(20);
        product.EditProductPrice(product.Price);
        Assert.IsTrue(product.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductStockQuantity_with_valid_value_should_return_IsValid()
    {
        var product = new Product(new ProductName("Product name"), new Price(1), new Quantity(1), 
            new Description("Product description"), new Manufacturer("Manufacturer"), 
            new FileName("fileName.png"), new UrlString("https://balta.io/"));
        product.EditProductStockQuantity(new Quantity(1));
        Assert.IsTrue(product.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductDescription_with_valid_value_should_return_IsValid()
    {
        var product = new Product(new ProductName("Product name"), new Price(1), new Quantity(1), 
            new Description("Product description"), new Manufacturer("Manufacturer"), 
            new FileName("fileName.png"), new UrlString("https://balta.io/"));
        product.EditProductDescription(new Description("New product description."));
        Assert.IsTrue(product.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductManufacturer_with_valid_value_should_return_IsValid()
    {
        var product = new Product(new ProductName("Product name"), new Price(1), new Quantity(1), 
            new Description("Product description"), new Manufacturer("Manufacturer"), 
            new FileName("fileName.png"), new UrlString("https://balta.io/"));
        product.EditProductManufacturer(new Manufacturer("Valid manufacturer"));
        Assert.IsTrue(product.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductImage_with_valid_value_should_return_IsValid()
    {
        var product = new Product(new ProductName("Product name"), new Price(1), new Quantity(1), 
            new Description("Product description"), new Manufacturer("Manufacturer"), 
            new FileName("fileName.png"), new UrlString("https://balta.io/"));
        product.EditProductImageData(new FileName("newfile.png"), new UrlString("https://docs.microsoft.com"));
        Assert.IsTrue(product.IsValid);
    }
}
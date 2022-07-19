using CWebStore.Domain.Commands;

namespace CWebStore.Tests.Commands;

[TestClass]
public class CreateProductCommandTests
{
    [TestMethod]
    [TestCategory("CWebStore.Domain.Commands")]
    public void Given_CreateProductCommand_with_invalid_productName_should_return_error_message()
    {
        var product = new CreateProductCommand(string.Empty, "Product description", 
            "Manufacturer name", 1.30m, 10, 
            "imagefile.png", "https://docs.microsoft.com" );
        var message = "Product name must not be null or empty.";
        Assert.AreEqual(message, product.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Commands")]
    public void Given_CreateProductCommand_with_buy_value_and_invalid_sell_value_should_return_error_message()
    {
        var product = new CreateProductCommand(string.Empty, "Product description", 
            "Manufacturer name", 1, 1, 10, 
            "imagefile.png", "https://docs.microsoft.com" );
        var message = $"Sell value must be {product.Percentage}% greater than buy value";
        Assert.AreEqual(message, product.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Commands")]
    public void Given_CreateProductCommand_with_valid_ProductName_should_return_IsValid()
    {
        var category = new CreateProductCommand("Product name", "Product description", 
            "Manufacturer name", 1.30m, 10, 
            "imagefile.png", "https://docs.microsoft.com" );
        Assert.IsTrue(category.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Commands")]
    public void Given_CreateProductCommand_with_buy_value_and_valid_sell_value_should_return_IsValid()
    {
        var product = new CreateProductCommand(string.Empty, "Product description", 
            "Manufacturer name", 1.1m, 1, 10, 10, 
            "imagefile.png", "https://docs.microsoft.com" );
        Assert.IsTrue(product.IsValid);
    }
}
using CWebStore.Domain.Commands.ProductCommands;

namespace CWebStore.Tests.Commands;

[TestClass]
public class CreateProductCommandTests
{
    private readonly CreateProductCommand _command;

    public CreateProductCommandTests()
    {
        _command = new CreateProductCommand("Valid product name", "Product description", 
            "Manufacturer name", 10, 20, 10, 
            "imagefile.png", "https://docs.microsoft.com" );;
    }

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
    public void Given_CreateProductCommand_with_buy_value_and_percentage_sell_value_should_return_sell_value_correctly_calculated()
    {
        Assert.AreEqual(12, _command.SellValue);
    }
    
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Commands")]
    public void Given_CreateProductCommand_with_buy_value_and_percentage_should_return_IsValid()
    {
        Assert.IsTrue(_command.IsValid);
    }
}
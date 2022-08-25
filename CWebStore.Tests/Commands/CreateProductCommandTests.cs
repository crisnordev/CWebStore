using CWebStore.Domain.Commands.ProductCommands;
using CWebStore.Domain.Commands.ProductCommands.Request;

namespace CWebStore.Tests.Commands;

[TestClass]
public class CreateProductCommandTests
{
    public CreateProductCommandTests() { }

    [TestMethod]
    [TestCategory("CWebStore.Domain.Commands")]
    public void Given_CreateProductCommand_with_buy_value_and_percentage_sell_value_should_return_sell_value_correctly_calculated()
    {
        var command = new CreateProductRequestCommand("Valid product name", "Product description", 
            "Manufacturer name", 10, 20, 10, 
            "imagefile.png", "https://docs.microsoft.com" );;
        Assert.AreEqual(12, command.SellValue);
    }
}
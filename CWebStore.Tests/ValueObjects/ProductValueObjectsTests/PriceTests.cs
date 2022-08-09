namespace CWebStore.Tests.ValueObjects.ProductValueObjectsTests;

[TestClass]
public class PriceTests
{
    private readonly Price _price;

    public PriceTests()
    {
        _price = new Price(10, 10);
    }

    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_price_with_sell_value_equals_minus_1_should_return_error_message()
    {
        var price = new Price(-1);
        var message = "Sell value must not be lower than 0.";
        Assert.AreEqual(message, price.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_price_with_buy_value_equals_1_Percentage_minus_1_should_return_error_message()
    {
        var price = new Price(1, -1);
        var message = "Percentage must not be lower than 0.";
        Assert.AreEqual(message, price.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_price_with_buy_value_equals_minus_1_Percentage_1_should_return_error_message()
    {
        var price = new Price(-1, 10);
        var message = "Buy value must not be lower than 0.";
        Assert.AreEqual(message, price.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_price_EditSellValue_equals_minus_1_should_return_error_message()
    {
        _price.EditSellValue(-1);
        var message = "Sell value must not be lower than 0.";
        Assert.AreEqual(message, _price.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_price_EditBuyValue_equals_minus_1_should_return_error_message()
    {
        _price.EditBuyValue(-1);
        var message = "Buy value must not be lower than 0.";
        Assert.AreEqual(message, _price.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_price_EditPercentage_equals_minus_1_should_return_error_message()
    {
        _price.EditPercentage(-1);
        var message = "Percentage must not be lower than 0.";
        Assert.AreEqual(message, _price.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_sell_price_should_return_IsValid()
    {
        var price = new Price(1.05M);
        Assert.IsTrue(price.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_price_with_buyValue_and_percentage_should_return_IsValid_and_sellValue_correctly_calculated()
    {
        Assert.IsTrue(_price.IsValid && _price.SellValue == 11M);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_sell_price_EditSellValue_should_return_IsValid()
    {
        _price.EditSellValue(1.20M);
        Assert.IsTrue(_price.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_sell_price_with_buyValue_and_percentage_EditSellValue_should_return_IsValid_and_percentage_correctly_calculated()
    {
        _price.EditSellValue(12M);
        Assert.IsTrue(_price.IsValid && _price.Percentage == 20);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_price_EditSellValue_with_sellValue_lower_than_buyValue_should_return_buyValue_and_percentage_equals_0()
    {
        _price.EditSellValue(0.50M);

        Assert.IsTrue(_price.BuyValue == 0 && _price.Percentage == 0);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_sell_price_EditBuyValue_should_return_IsValid_and_sellValue_correctly_calculated()
    {
        _price.EditBuyValue(2);
        Assert.IsTrue(_price.IsValid && _price.SellValue == 2.20M);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_price_EditPercentage_should_return_IsValid_and_sellValue_correctly_calculated()
    {
        _price.EditPercentage(20);
        Assert.IsTrue(_price.IsValid && _price.SellValue == 12);
    }
        
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_price_only_with_sellValue_EditPercentage_should_return_sellValue_and_buyValue_equals_0()
    {
        var price = new Price(10);
        price.EditPercentage(10);
        Assert.IsTrue(price.SellValue == 0 && price.BuyValue == 0);
    }
}
namespace CWebStore.Tests.ValueObjects.ProductValueObjectsTests;

[TestClass]
public class PriceTests
{
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
        var price = new Price(1);
        price.EditSellValue(-1);
        var message = "Sell value must not be lower than 0.";
        Assert.AreEqual(message, price.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_price_EditBuyValue_equals_minus_1_should_return_error_message()
    {
        var price = new Price(1);
        price.EditBuyValue(-1);
        var message = "Buy value must not be lower than 0.";
        Assert.AreEqual(message, price.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_price_EditPercentage_equals_minus_1_should_return_error_message()
    {
        var price = new Price(1);
        price.EditPercentage(-1);
        var message = "Percentage must not be lower than 0.";
        Assert.AreEqual(message, price.Notifications.First().Message);
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
    public void Given_a_valid_price_with_buyValue_and_percentage_should_return_IsValid()
    {
        var price = new Price(1, 10);
        Assert.IsTrue(price.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_sell_price_EditSellValue_should_return_IsValid()
    {
        var price = new Price(1.05M);
        price.EditSellValue(1.20M);
        Assert.IsTrue(price.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_sell_price_with_buyValue_and_percentage_EditSellValue_should_return_IsValid()
    {
        var price = new Price(1, 10);
        price.EditSellValue(1.20M);
        Assert.IsTrue(price.IsValid);
    }

    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_price_EditSellValue_should_return_percentage_correctly_calculated()
    {
        var price = new Price(2, 20);
        price.EditSellValue(2.60M);

        Assert.AreEqual(30, price.Percentage);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_price_EditSellValue_with_greater_buy_value_should_return_buyValue_and_percentage_equals_0()
    {
        var price = new Price(2, 20);
        price.EditSellValue(1);
        bool result = price.BuyValue == 0 && price.Percentage == 0;

        Assert.IsTrue(result);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_sell_price_EditBuyValue_should_return_IsValid()
    {
        var price = new Price(1, 20);
        price.EditBuyValue(2);
        Assert.IsTrue(price.IsValid);
    }

    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_price_EditBuyValue_should_return_sellValue_correctly_calculated()
    {
        var price = new Price(1, 20);
        price.EditBuyValue(2);
        Assert.AreEqual(2.40M, price.SellValue);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_sell_price_EditPercentage_should_return_IsValid()
    {
        var price = new Price(1, 10);
        price.EditSellValue(2);
        Assert.IsTrue(price.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_price_EditPercentage_should_return_sellValue_equals_0()
    {
        var price = new Price(10);
        price.EditPercentage(10);
        Assert.AreEqual(0, price.SellValue);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_price_EditPercentage_should_return_sellValue_correctly_calculated()
    {
        var price = new Price(10, 10);
        price.EditPercentage(20);
        Assert.AreEqual(12, price.SellValue);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_price_with_buyValue_equals_0_EditPercentage_should_return_sellValue_equals_0()
    {
        var price = new Price(10);
        price.EditPercentage(20);
        Assert.AreEqual(0, price.SellValue);
    }
}
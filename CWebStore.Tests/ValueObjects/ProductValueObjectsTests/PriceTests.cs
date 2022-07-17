namespace CWebStore.Tests.ValueObjects.ProductValueObjectsTests;

[TestClass]
public class PriceTests
{
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_price_with_sell_value_equals_0_should_return_error_message()
    {
        var price = new Price(0m);
        var message = "Sell value must not be lower or equals 0.";
        Assert.AreEqual(message, price.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_price_with_sell_value_equals_200001_should_return_error_message()
    {
        var price = new Price(200001m);
        var message = "Sell value must not be greater than 200000.";
        Assert.AreEqual(message, price.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_valid_price_EditSellValue_with_sell_value_equals_0_should_return_error_message()
    {
        var price = new Price(1m);
        price.EditSellValue(0m);
        var message = "Sell value must not be lower or equals 0.";
        Assert.AreEqual(message, price.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_valid_price_EditSellValue_with_sell_value_equals_200001_should_return_error_message()
    {
        var price = new Price(1m);
        price.EditSellValue(200001m);
        var message = "Sell value must not be greater than 200000.";
        Assert.AreEqual(message, price.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_price_EditBuyValue_with_buy_value_equals_minus_1_should_return_error_message()
    {
        var price = new Price(1m);
        price.EditBuyValue(-1m, 10);
        var message = "Buy value must not be lower than 0.";
        Assert.AreEqual(message, price.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_price_EditBuyValue_with_value_equals_100001_should_return_error_message()
    {
        var price = new Price(1m);
        price.EditBuyValue(100001m, 10);
        var message = "This value must not be greater than 100000.";
        Assert.AreEqual(message, price.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_price_EditBuyValue_with_percentage_value_equals_0_should_return_error_message()
    {
        var price = new Price(1m);
        price.EditBuyValue(1, 0);
        var message = "Percentage must have a value greater than 0.";
        Assert.AreEqual(message, price.Notifications.First().Message);
    }

    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_price_EditPercentage_with_percentage_equals_minus_1_should_return_error_message()
    {
        var price = new Price(1m);
        price.EditPercentage(1, -1m);
        var message = "Percentage must not be lower than 0.";
        Assert.AreEqual(message, price.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_price_EditPercentage_with_percentage_equals_101_should_return_error_message()
    {
        var price = new Price(1m);
        price.EditPercentage(1, 101m);
        var message = "Percentage must not be greater than 100.";
        Assert.AreEqual(message, price.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_price_EditPercentage_with_buy_value_equals_0_should_return_error_message()
    {
        var price = new Price(1m);
        price.EditPercentage(0, 10);
        var message = "Buy price must have a value.";
        Assert.AreEqual(message, price.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_valid_sell_price_should_return_IsValid()
    {
        var price = new Price(1.05m);
        Assert.IsTrue(price.IsValid);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_valid_sell_price_EditSellValue_should_return_buy_and_sell_value_IsValid()
    {
        var price = new Price(1.05m);
        price.EditSellValue(1.20m);
        Assert.IsTrue(price.IsValid);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_valid_price_EditBuyValue_with_buy_value_1_and_percentage_10_should_return_sell_as_1_dot_10_and_IsValid()
    {
        var price = new Price(1m);
        price.EditBuyValue(1, 10);
        Assert.AreEqual(1.10m, price.SellValue);
        Assert.IsTrue(price.IsValid);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_valid_price_EditPercentage_with_buy_value_1_percentage_equals_20_should_return_sell_as_1_dot_20_and_IsValid()
    {
        var price = new Price(1.10m);
        price.EditPercentage(1, 20m);
        Assert.AreEqual(1.20m, price.SellValue);
        Assert.IsTrue(price.IsValid);
    }
}
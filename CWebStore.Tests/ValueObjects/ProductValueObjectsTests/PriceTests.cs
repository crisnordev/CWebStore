namespace CWebStore.Tests.ValueObjects.ProductValueObjectsTests;

[TestClass]
public class PriceTests
{
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_price_with_sell_value_equals_0_should_return_IsGreaterThan_error_message()
    {
        var price = new Price(0m);
        price.EditBuyValue(0m);
        price.EditPercentage(0m);
        var message = "This value must not be lower or equals 0.";
        var priceError = price.Notifications.FirstOrDefault();
        Assert.AreEqual(message, priceError.Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_price_with_sell_value_equals_200001_should_return_IsLowerThan_error_message()
    {
        var price = new Price(200001m);
        var message = "This value must not be greater than 200000.";
        var priceError = price.Notifications.FirstOrDefault();
        Assert.AreEqual(message, priceError.Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_valid_price_EditSellValue_with_sell_value_equals_0_should_return_IsGreaterThan_error_message()
    {
        var price = new Price(1m);
        price.EditSellValue(0m);
        var message = "This value must not be lower or equals 0.";
        var priceError = price.Notifications.FirstOrDefault();
        Assert.AreEqual(message, priceError.Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_valid_price_EditSellValue_with_sell_value_equals_200001_should_return_IsLowerThan_error_message()
    {
        var price = new Price(1m);
        price.EditSellValue(200001m);
        var message = "This value must not be greater than 200000.";
        var priceError = price.Notifications.FirstOrDefault();
        Assert.AreEqual(message, priceError.Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_price_with_buy_value_equals_minus_1_should_return_IsGreaterOrEqualsThan_error_message()
    {
        var price = new Price(1m);
        price.EditBuyValue(-1m);
        var message = "This value must not be lower than 0.";
        var priceError = price.Notifications.FirstOrDefault();
        Assert.AreEqual(message, priceError.Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_price_with_buy_value_equals_100001_should_return_IsLowerThan_error_message()
    {
        var price = new Price(1m);
        price.EditBuyValue(100001m);
        var message = "This value must not be greater than 100000.";
        var priceError = price.Notifications.FirstOrDefault();
        Assert.AreEqual(message, priceError.Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_price_with_percentage_equals_minus_1_should_return_IsGreaterOrEqualsThan_error_message()
    {
        var price = new Price(1m);
        price.EditPercentage(-1m);
        var message = "Percentage must not be lower than 0.";
        var priceError = price.Notifications.FirstOrDefault();
        Assert.AreEqual(message, priceError.Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_price_with_percentage_equals_101_should_return_IsLowerThan_error_message()
    {
        var price = new Price(1m);
        price.EditPercentage(101m);
        var message = "Percentage must not be greater than 100.";
        var priceError = price.Notifications.FirstOrDefault();
        Assert.AreEqual(message, priceError.Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_valid_price_with_buy_and_percentage_value_equals_0_should_return_IsValid()
    {
        var price = new Price(1.05m);
        price.EditBuyValue(0m);
        price.EditPercentage(0m);
        Assert.IsTrue(price.IsValid);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_valid_price_with_buy_value_equals_1_and_percentage_equals_10_should_return_sell_as_1_dot_10()
    {
        var price = new Price(1m);
        price.EditBuyValue(1m);
        price.EditPercentage(10m);
        Assert.AreEqual(1.10m, price.SellValue);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_valid_price_with_buyValue_1_percentage_10_increasing_percentage_to_20_should_return_sell_as_1_dot_20()
    {
        var price = new Price(1.10m);
        price.EditBuyValue(1m);
        price.EditPercentage(10m);
        price.EditPercentage(20m);
        Assert.AreEqual(1.20m, price.SellValue);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_valid_price_with_buyValue_1_percentage_10_increasing_sellValue_to_1_dot_20_should_return_percentage_as_20()
    {
        var price = new Price(1.10m);
        price.EditBuyValue(1m);
        price.EditPercentage(10m);
        price.EditSellValue(1.20m);
        Assert.AreEqual(20m, price.Percentage);
    }
}
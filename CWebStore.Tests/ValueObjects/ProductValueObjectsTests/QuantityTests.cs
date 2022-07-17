namespace CWebStore.Tests.ValueObjects.ProductValueObjectsTests;

[TestClass]
public class QuantityTests
{
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_quantity_value_lower_than_0_should_return_error_message()
    {
        var quantity = new Quantity(-1);
        var message = "Quantity must not be lower than 0.";
        Assert.AreEqual(message, quantity.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_quantity_value_equals_1000001_should_return_error_message()
    {
        var quantity = new Quantity(1000001);
        var message = "Quantity must not be greater than 1000000";
        Assert.AreEqual(message, quantity.Notifications.First().Message);
    }

    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_valid_quantity_EditQuantityValue_invalid_should_return_error_message()
    {
        var quantity = new Quantity(1);
        quantity.EditQuantityValue(-1);
        var message = "Quantity must not be lower than 0.";
        Assert.AreEqual(message, quantity.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_valid_quantity_value_should_return_IsValid_true()
    {
        var quantity = new Quantity(1);
        Assert.IsTrue(quantity.IsValid);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_valid_quantity_EditQuantityValue_valid_should_return_IsValid()
    {
        var quantity = new Quantity(1);
        quantity.EditQuantityValue(2);
        Assert.IsTrue(quantity.IsValid);
    }
}
namespace CWebStore.Tests.ValueObjects;

[TestClass]
public class QuantityTests
{
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_quantity_value_equals_0_should_return_IsLowerThan_error_message()
    {
        var quantity = new Quantity(-1);
        var message = "Quantity must not be lower or equals 0.";
        var quantityError = quantity.Notifications.FirstOrDefault();
        Assert.AreEqual(message, quantityError.Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_quantity_value_equals_1000001_should_return_IsGreaterThan_error_message()
    {
        var quantity = new Quantity(1000001);
        var message = "Quantity must not be greater than 1000000";
        var quantityError = quantity.Notifications.FirstOrDefault();
        Assert.AreEqual(message, quantityError.Message);
    }
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_valid_quantity_EditQuantityValue_value_equals_0_should_return_IsLowerThan_error_message()
    {
        var quantity = new Quantity(1);
        quantity.EditQuantityValue(-1);
        var message = "Quantity must not be lower or equals 0.";
        var quantityError = quantity.Notifications.FirstOrDefault();
        Assert.AreEqual(message, quantityError.Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_valid_quantity_EditQuantityValue_value_equals_1000001_should_return_IsGreaterThan_error_message()
    {
        var quantity = new Quantity(1);
        quantity.EditQuantityValue(1000001);
        var message = "Quantity must not be greater than 1000000";
        var quantityError = quantity.Notifications.FirstOrDefault();
        Assert.AreEqual(message, quantityError.Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_valid_quantity_value_equals_1_should_return_IsValid_true()
    {
        var quantity = new Quantity(1);
        Assert.IsTrue(quantity.IsValid);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_valid_quantity_EditQuantityValue_value_equals_2_should_return_IsValid()
    {
        var quantity = new Quantity(1);
        quantity.EditQuantityValue(2);
        Assert.IsTrue(quantity.IsValid);
    }
}
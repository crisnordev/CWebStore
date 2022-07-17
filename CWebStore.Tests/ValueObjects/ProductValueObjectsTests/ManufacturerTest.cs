namespace CWebStore.Tests.ValueObjects.ProductValueObjectsTests;

[TestClass]
public class ManufacturerTest
{
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_manufacturer_should_return_IsNotNullOrEmpty_error_message()
    {
        var manufacturer = new Manufacturer(string.Empty);
        var message = "Manufacturer name must not be null or empty.";
        Assert.AreEqual(message, manufacturer.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_manufacturer_should_return_IsLowerThan_error_message()
    {
        var manufacturer = new Manufacturer("a");
        var message = "Manufacturer name must have two or more characters.";
        Assert.AreEqual(message, manufacturer.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_manufacturer_should_return_IsGreaterThan_error_message()
    {
        var great = "aaaaaaaa10aaaaaaaa20aaaaaaaa30aaaaaaaa40";
        var manufacturer = new Manufacturer(great + great + great + "1");
        var message = "Manufacturer name must have 120 or less characters.";
        Assert.AreEqual(message, manufacturer.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_manufacturer_EditManufacturerVOName_invalid_should_return_error_message()
    {
        var manufacturer = new Manufacturer("Valid Name");
        manufacturer.EditManufacturerVOName(string.Empty);
        var message = "Manufacturer name must not be null or empty.";
        Assert.AreEqual(message, manufacturer.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_valid_manufacturer_should_return_IsValid()
    {
        var manufacturer = new Manufacturer("Valid Name");
        Assert.IsTrue(manufacturer.IsValid);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_valid_manufacturer_EditManufacturerVOName_should_return_IsValid()
    {
        var manufacturer = new Manufacturer("Valid Name");
        manufacturer.EditManufacturerVOName("Another Valid Name");
        Assert.IsTrue(manufacturer.IsValid);
    }
}
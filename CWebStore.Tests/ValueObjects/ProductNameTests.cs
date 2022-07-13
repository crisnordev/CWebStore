namespace CWebStore.Tests.ValueObjects;

[TestClass]
public class ProductNameTests
{
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_product_name_should_return_IsNotNullOrEmpty_error_message()
    {
        var productName = new ProductName(string.Empty);
        var message = "Product name must not be null or empty.";
        var productError = productName.Notifications.First();
        Assert.AreEqual(message, productError.Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_product_name_should_return_IsLowerThan_error_message()
    {
        var productName = new ProductName("a");
        var message = "Product name must have two or more characters.";
        var productError = productName.Notifications.First();
        Assert.AreEqual(message, productError.Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_product_name_should_return_IsGreaterThan_error_message()
    {
        var great = "aaaaaaaa10aaaaaaaa20aaaaaaaa30aaaaaaaa40";
        var productName = new ProductName(great + great + great + great + great + great + "1");
        var message = "Product name must have 160 or less characters.";
        var productError = productName.Notifications.First();
        Assert.AreEqual(message, productError.Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_valid_product_name_should_return_IsValid()
    {
        var productName = new ProductName("Valid product name");
        Assert.IsTrue(productName.IsValid);
    }
    
}
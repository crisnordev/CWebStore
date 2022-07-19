namespace CWebStore.Tests.ValueObjects.ProductValueObjectsTests;

[TestClass]
public class ProductNameTests
{
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_product_name_empty_should_return_error_message()
    {
        var productName = new ProductName(string.Empty);
        var message = "Product name must not be null or empty.";
        Assert.AreEqual(message, productName.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_product_name_with_one_char_should_return_error_message()
    {
        var productName = new ProductName("a");
        var message = "Product name must have two or more characters.";
        Assert.AreEqual(message, productName.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_product_name_with_121_char_should_return_error_message()
    {
        var great = "aaaaaaaa10aaaaaaaa20aaaaaaaa30aaaaaaaa40";
        var productName = new ProductName(great + great + great +  "1");
        var message = "Product name must have 120 or less characters.";
        Assert.AreEqual(message, productName.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_product_name_EditProductNameVOName_invalid_should_return_error_message()
    {
        var productName = new ProductName(string.Empty);
        var message = "Product name must not be null or empty.";
        Assert.AreEqual(message, productName.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_product_name_should_return_IsValid()
    {
        var productName = new ProductName("Valid product name");
        Assert.IsTrue(productName.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_product_name_EditProductNameVOName_valid_should_return_IsValid()
    {
        var productName = new ProductName("Valid product name");
        productName.EditProductNameVOName("Another valid Name");
        Assert.IsTrue(productName.IsValid);
    }
}
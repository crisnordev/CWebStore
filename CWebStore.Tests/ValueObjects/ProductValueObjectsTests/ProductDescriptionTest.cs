namespace CWebStore.Tests.ValueObjects.ProductValueObjectsTests;

[TestClass]
public class ProductDescriptionTest
{
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_product_description_should_return_IsNotNullOrEmpty_error_message()
    {
        var productDescription = new Description(string.Empty);
        var message = "Product description must not be null or empty.";
        Assert.AreEqual(message, productDescription.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_product_description_should_return_IsLowerThan_error_message()
    {
        var productDescription = new Description("a");
        var message = "Product description must have two or more characters.";
        Assert.AreEqual(message, productDescription.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_product_description_should_return_IsGreaterThan_error_message()
    {
        var great = "aaaaaaaa10aaaaaaaa20aaaaaaaa30aaaaaaaa40";
        var productDescription = new Description(great + great + great + great +"1");
        var message = "Product description must have 160 or less characters.";
        Assert.AreEqual(message, productDescription.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_product_description_EditDescriptionVOText_invalid_should_return_error_message()
    {
        var productDescription = new Description("This is a valid product description");
        productDescription.EditDescriptionVOText(string.Empty);
        var message = "Product description must not be null or empty.";
        Assert.AreEqual(message, productDescription.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_product_description_should_return_IsValid()
    {
        var productDescription = new Description("This is a valid product description");
        Assert.IsTrue(productDescription.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_product_description_EditDescriptionVOText_should_return_IsValid()
    {
        var productDescription = new Description("This is a valid product description");
        productDescription.EditDescriptionVOText("This is another valid product description");
        Assert.IsTrue(productDescription.IsValid);
    }
}
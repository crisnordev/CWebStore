namespace CWebStore.Tests.ValueObjects;

[TestClass]
public class ProductDescriptionTest
{
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_product_description_should_return_IsNotNullOrEmpty_error_message()
    {
        var productDescription = new ProductDescription(string.Empty);
        var message = "Product description must not be null or empty.";
        var productDescriptionError = productDescription.Notifications.First();
        Assert.AreEqual(message, productDescriptionError.Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_product_description_should_return_IsLowerThan_error_message()
    {
        var productDescription = new ProductDescription("a");
        var message = "Product description must have two or more characters.";
        var productDescriptionError = productDescription.Notifications.First();
        Assert.AreEqual(message, productDescriptionError.Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_product_description_should_return_IsGreaterThan_error_message()
    {
        var great = "aaaaaaaa10aaaaaaaa20aaaaaaaa30aaaaaaaa40";
        var productDescription = new ProductDescription(great + great + great + great +"1");
        var message = "Product description must have 160 or less characters.";
        var productDescriptionError = productDescription.Notifications.First();
        Assert.AreEqual(message, productDescriptionError.Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_valid_product_description_should_return_IsValid()
    {
        var productDescription = new ProductDescription("This is a vaslid product description");
        Assert.IsTrue(productDescription.IsValid);
    }
}
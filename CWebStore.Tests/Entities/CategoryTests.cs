namespace CWebStore.Tests.Entities;

[TestClass]
public class CategoryTests
{
    [TestMethod]
    [TestCategory("ProductApi.Entities")]
    public void Given_a_string_empty_category_should_return_IsNotNullOrEmpty_error_message()
    {
        var category = new Category(new CategoryName(string.Empty));
        var message = "Category name must not be null or empty.";
        var categoryError = category.Notifications.First();
        Assert.AreEqual(message, categoryError.Message);
    }

    [TestMethod]
    [TestCategory("ProductApi.Entities")]
    public void Given_a_valid_category_AddProduct_with_invalid_product_should_return_error_message()
    {
        var category = new Category(new CategoryName("Category name"));
        var product = new Product(new ProductName(string.Empty), new Price(1), new Quantity(1),
            new ProductDescription("Valid description"), new Manufacturer("Manufacturer"),
            new FileName("file.png"), new UrlString("https://docs.microsoft.com/"));
        category.AddProduct(product);
        var message = "Product name must not be null or empty.";
        var categoryError = category.Notifications.First();
        Assert.AreEqual(message, categoryError.Message);
    }

    [TestMethod]
    [TestCategory("ProductApi.Entities")]
    public void Given_a_valid_category_EditCategoryName_with_string_empty_should_return_IsNotNullOrEmpty_error_message()
    {
        var category = new Category(new CategoryName("Category name"));
        category.EditCategoryName(string.Empty);
        var message = "Category name must not be null or empty.";
        var categoryError = category.Notifications.First();
        Assert.AreEqual(message, categoryError.Message);
    }

    [TestMethod]
    [TestCategory("ProductApi.Entities")]
    public void
        Given_a_valid_category_AddProduct_with_product_which_has_already_been_Added_should_return_error_message()
    {
        var category = new Category(new CategoryName("Category name"));
        var product = new Product(new ProductName("Product name"), new Price(1), new Quantity(1),
            new ProductDescription("Valid description"), new Manufacturer("Manufacturer"),
            new FileName("file.png"), new UrlString("https://docs.microsoft.com/"));
        var product2 = product;
        category.AddProduct(product);
        category.AddProduct(product2);
        var message = "This product has already been added.";
        var categoryError = category.Notifications.First();
        Assert.AreEqual(message, categoryError.Message);
    }

    [TestMethod]
    [TestCategory("ProductApi.Entities")]
    public void Given_a_valid_category_RemoveProduct_using_invalid_product_should_return_error_message()
    {
        var category = new Category(new CategoryName("Category name"));
        var product = new Product(new ProductName("Product name"), new Price(1), new Quantity(1),
            new ProductDescription("Valid description"), new Manufacturer("Manufacturer"),
            new FileName("file.png"), new UrlString("https://docs.microsoft.com/"));
        category.AddProduct(product);
        var productInvalid = new Product(new ProductName(""), new Price(1), new Quantity(1),
            new ProductDescription("Valid description"), new Manufacturer("Manufacturer"),
            new FileName("file.png"), new UrlString("https://docs.microsoft.com/"));
        category.RemoveProduct(productInvalid);
        var message = "It is not possible to remove this product.";
        var categoryError = category.Notifications.First();
        Assert.AreEqual(message, categoryError.Message);
    }

    [TestMethod]
    [TestCategory("ProductApi.Entities")]
    public void Given_a_valid_category_RemoveProduct_using_product_which_is_not_in_list_should_return_error_message()
    {
        var category = new Category(new CategoryName("Category name"));
        var product = new Product(new ProductName("Product name"), new Price(1), new Quantity(1),
            new ProductDescription("Valid description"), new Manufacturer("Manufacturer"),
            new FileName("file.png"), new UrlString("https://docs.microsoft.com/"));
        category.AddProduct(product);
        var product2 = new Product(new ProductName("Product name"), new Price(1), new Quantity(1),
            new ProductDescription("Valid description"), new Manufacturer("Manufacturer"),
            new FileName("file.png"), new UrlString("https://docs.microsoft.com/"));
        category.RemoveProduct(product2);
        var message = "It is not possible to remove this product.";
        var categoryError = category.Notifications.First();
        Assert.AreEqual(message, categoryError.Message);
    }

    [TestMethod]
    [TestCategory("ProductApi.Entities")]
    public void Given_a_valid_category_should_return_IsValid()
    {
        var category = new Category(new CategoryName("Category name"));
        Assert.IsTrue(category.IsValid);
    }

    [TestMethod]
    [TestCategory("ProductApi.Entities")]
    public void Given_a_valid_category_AddProduct_should_return_IsValid()
    {
        var category = new Category(new CategoryName("Category name"));
        var product = new Product(new ProductName("Product name"), new Price(1), new Quantity(1),
            new ProductDescription("Valid description"), new Manufacturer("Manufacturer"),
            new FileName("file.png"), new UrlString("https://docs.microsoft.com/"));
        category.AddProduct(product);
        Assert.IsTrue(category.IsValid);
    }

    [TestMethod]
    [TestCategory("ProductApi.Entities")]
    public void Given_a_valid_category_EditCategoryName_with_valid_name_should_return_IsValid()
    {
        var category = new Category(new CategoryName("Category name"));
        category.EditCategoryName("New category Name");
        Assert.IsTrue(category.IsValid);
    }

    [TestMethod]
    [TestCategory("ProductApi.Entities")]
    public void Given_a_valid_category_RemoveProduct_should_return_IsValid()
    {
        var category = new Category(new CategoryName("Category name"));
        var product = new Product(new ProductName("Product name"), new Price(1), new Quantity(1),
            new ProductDescription("Valid description"), new Manufacturer("Manufacturer"),
            new FileName("file.png"), new UrlString("https://docs.microsoft.com/"));
        category.AddProduct(product);
        category.RemoveProduct(product);
        Assert.IsTrue(category.IsValid);
    }
}


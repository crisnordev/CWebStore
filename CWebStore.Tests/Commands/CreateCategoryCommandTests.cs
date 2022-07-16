using CWebStore.Domain.Commands;

namespace CWebStore.Tests.Commands;

[TestClass]
public class CreateCategoryCommandTests
{
    [TestMethod]
    [TestCategory("ProductApi.Entities")]
    public void Given_category_with_invalid_name_should_return_error_message()
    {
        var category = new CreateCategoryCommand(string.Empty);
        var message = "Category name must not be null or empty.";
        Assert.AreEqual(message, category.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.Entities")]
    public void Given_category_with_valid_name_should_return_IsValid()
    {
        var category = new CreateCategoryCommand("Category name");
        var message = "Category name must not be null or empty.";
        Assert.IsTrue(category.IsValid);
    }
}
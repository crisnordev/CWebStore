using CWebStore.Domain.Commands.CategoryCommands;

namespace CWebStore.Tests.Commands;

[TestClass]
public class CreateCategoryCommandTests
{
    [TestMethod]
    [TestCategory("CWebStore.Domain.Commands")]
    public void Given_CreateCategoryCommand_with_invalid_CategoryName_should_return_error_message()
    {
        var category = new CreateCategoryCommand(string.Empty);
        var message = "Category name must not be null or empty.";
        Assert.AreEqual(message, category.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Commands")]
    public void Given_CreateCategoryCommand_with_valid_name_should_return_IsValid()
    {
        var category = new CreateCategoryCommand("Category name");
        Assert.IsTrue(category.IsValid);
    }
}
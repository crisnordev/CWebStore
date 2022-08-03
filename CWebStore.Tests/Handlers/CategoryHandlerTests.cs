using CWebStore.Domain.Commands.CategoryCommands;
using CWebStore.Domain.Handlers.CategoryHandlers;
using CWebStore.Domain.Repositories.Interfaces;
using Moq;

namespace CWebStore.Tests.Handlers;

[TestClass]
public class CategoryHandlerTests
{
    private readonly Mock<ICategoryRepository> _mock;

    public CategoryHandlerTests()
    {
        _mock = new Mock<ICategoryRepository>();
    }

    [TestMethod]
    [TestCategory("CWebStore.Domain.Handlers")]
    public void Given_an_invalid_category_name_CategoryHandler_should_return_CommandResult_error_message()
    {
        var handler = new CategoryHandler(_mock.Object);
        var handlerResult = handler.Handle(new CreateCategoryCommand(string.Empty)) as Result;

        var error = "Category name must not be null or empty.";
        var message = "This is not a valid Category.";
        Assert.AreEqual(error, handlerResult.Notifications.First().Message);
        Assert.AreEqual(message, handlerResult.Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Handlers")]
    public void Given_already_existing_category_CategoryHandler_should_return_CommandResult_error_messages_and_notifications()
    {
        _mock.Setup(x => x.CategoryExists("Category name")).Returns(true);
        var handler = new CategoryHandler(_mock.Object);
        var result = handler.Handle(new CreateCategoryCommand("Category name")) as Result;

        var message = "This category already exists.";
        Assert.AreEqual(message, result.Message);
    }

    [TestMethod]
    [TestCategory("CWebStore.Domain.Handlers")]
    public void Given_categoryCommand_CategoryHandler_should_return_CommandResult_success_message()
    {
        var command = new CreateCategoryCommand("Last Category name");
        var handler = new CategoryHandler(_mock.Object);
        var result = handler.Handle(command) as Result;

        var message = "Category was successfully created.";
        Assert.AreEqual(message, result.Message);
    }
}
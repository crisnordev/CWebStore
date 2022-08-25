using CWebStore.Domain.Commands.CategoryCommands.Request;
using CWebStore.Domain.Commands.CategoryCommands.Response;
using CWebStore.Domain.Handlers.CategoryHandlers;
using CWebStore.Tests.Mocks;

namespace CWebStore.Tests.Handlers;

[TestClass]
public class CategoryCommandHandlerTests
{
    private readonly FakeCategoryRepository _categoryRepository;

    public CategoryCommandHandlerTests()
    {
        _categoryRepository = new FakeCategoryRepository();
    }

    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Handlers")]
    public void Given_already_existing_category_CategoryHandler_should_return_CommandResult_error_messages_and_notifications()
    {
        var handler = new CategoryCommandsHandler(_categoryRepository);
        var result = handler.Handle(new CreateCategoryRequestCommand("Category name")) as 
            Result<CreateCategoryResponseCommand>;

        Assert.AreEqual("Category exists.", result.Message);
    }

    [TestMethod]
    [TestCategory("CWebStore.Domain.Handlers")]
    public void Given_categoryCommand_CategoryHandler_should_return_Result_success_message()
    {
        var command = new CreateCategoryRequestCommand("Last Category name");
        var handler = new CategoryCommandsHandler(_categoryRepository);
        var result = handler.Handle(command) as Result<CreateCategoryResponseCommand>;

        Assert.AreEqual("Category was successfully created.", result.Message);
    }
}
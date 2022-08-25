using CWebStore.Domain.Commands.ProductCommands.Request;
using CWebStore.Domain.Commands.ProductCommands.Response;
using CWebStore.Domain.Handlers.ProductHandlers;
using CWebStore.Tests.Mocks;

namespace CWebStore.Tests.Handlers;

[TestClass]
public class ProductHandlerTests
{
    private readonly FakeProductRepository _repository;

    private readonly CreateProductRequestCommand _command;

    public ProductHandlerTests()
    {
        _repository = new FakeProductRepository();
        _command = new CreateProductRequestCommand("Product name", "Description", 
            "Manufacturer", 10, 10, "filename.png",
            "https://github.com");
    }

    [TestMethod]
    [TestCategory("CWebStore.Domain.Handlers")]
    public void Given_already_existing_product_ProductHandler_should_return_CommandResult_error_messages_and_list()
    {
        var handler = new ProductCommandsHandler(_repository);
        var result = handler.Handle(_command) as Result<CreateProductResponseCommand>;

        Assert.AreEqual("Product exists.", result.Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Handlers")]
    public void Given_categoryCommand_CategoryHandler_should_return_CommandResult_success_message()
    {
        var handler = new ProductCommandsHandler(_repository);
        var result = handler.Handle(_command) as Result<CreateProductResponseCommand>;

        Assert.AreEqual("Product created.", result.Message);
    }
}
using CWebStore.Domain.Commands;
using CWebStore.Domain.Commands.ProductCommands;
using CWebStore.Domain.Handlers.ProductHandlers;
using CWebStore.Domain.Repositories.Interfaces;
using Moq;

namespace CWebStore.Tests.Handlers;

[TestClass]
public class ProductHandlerTests
{
    private readonly Mock<IProductRepository> _repositoryMock;

    public ProductHandlerTests()
    {
        _repositoryMock = new Mock<IProductRepository>();
    }

    [TestMethod]
    [TestCategory("CWebStore.Domain.Handlers")]
    public void Given_an_invalid_product_name_ProductHandler_should_return_CommandResult_error_message()
    {
        var command = new CreateProductCommand(string.Empty, "Description", 
            "Manufacturer", 10, 10, "filename.png",
            "https://github.com");
        var handler = new ProductHandler(_repositoryMock.Object);
        var handlerResult = handler.Handle(command) as CommandResult;

        var error = "Product name must not be null or empty.";
        var message = "This is not a valid Product.";
        Assert.AreEqual(error, handlerResult.Errors.FirstOrDefault().Message);
        Assert.AreEqual(message, handlerResult.Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Handlers")]
    public void Given_already_existing_product_ProductHandler_should_return_CommandResult_error_messages_and_list()
    {
        var command = new CreateProductCommand("Product name", "Description", 
            "Manufacturer", 10, 10, "filename.png",
            "https://github.com");
        _repositoryMock.Setup(x => x.ProductExists("Product name")).Returns(true);
        var handler = new ProductHandler(_repositoryMock.Object);
        var result = handler.Handle(command) as CommandResult;

        var message = "This Product already exists.";
        Assert.AreEqual(message, result.Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Handlers")]
    public void Given_categoryCommand_CategoryHandler_should_return_CommandResult_success_message()
    {
        var command = new CreateProductCommand("Product name", "Description", 
            "Manufacturer", 10, 10, "filename.png",
            "https://github.com");
        _repositoryMock.Setup(x => x.ProductExists("Category name")).Returns(false);
        var handler = new ProductHandler(_repositoryMock.Object);
        var result = handler.Handle(command) as CommandResult;

        var message = "Product successfully saved.";
        Assert.AreEqual(message, result.Message);
    }
}
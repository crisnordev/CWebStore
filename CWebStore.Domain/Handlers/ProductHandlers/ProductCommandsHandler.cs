using CWebStore.Domain.Commands.ProductCommands.Request;
using CWebStore.Domain.Commands.ProductCommands.Response;

namespace CWebStore.Domain.Handlers.ProductHandlers;

public class ProductCommandsHandler : Notifiable<Notification>, ICommandHandler<CreateProductRequestCommand>
{
    private readonly IProductRepository _repository;

    public ProductCommandsHandler(IProductRepository repository)
    {
        _repository = repository;
    }
    
    public IResult Handle(CreateProductRequestCommand command)
    {
        var productExists = _repository.ProductExists(command.ProductName);
        if (productExists.Result)
            return new Result<CreateProductRequestCommand>(false, command, "This product already exists.");

        var product = new Product(new ProductName(command.ProductName), new Price(command.SellValue),
            new Quantity(command.StockQuantity), new Description(command.ProductDescription),
            new Manufacturer(command.ManufacturerName), new FileName(command.ImageFileName),
            new UrlString(command.ImageUrl));
        
        _repository.PostProduct(product);

        return new Result<CreateProductResponseCommand>(true, product, "Product created.");
    }
}
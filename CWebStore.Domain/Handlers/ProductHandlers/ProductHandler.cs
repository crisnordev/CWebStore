using CWebStore.Domain.Commands.ProductCommands;

namespace CWebStore.Domain.Handlers.ProductHandlers;

public class ProductHandler : Notifiable<Notification>, IHandler<CreateProductCommand>
{
    private readonly IProductRepository _repository;

    public ProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public IResult Handle(CreateProductCommand command)
    {
        command.Validate();
        if(!command.IsValid)
        {
            return new Result(false, "This is not a valid Product.", 
                command.Notifications.ToList());
        }

        if (_repository.ProductExists(command.ProductName))
            return new Result(true, "This Product already exists.");

        var product = new Product(new ProductName(command.ProductName), new Price(command.SellValue), 
            new Quantity(command.StockQuantity), new Description(command.ProductDescription), 
            new Manufacturer(command.ManufacturerName), new FileName(command.ImageFileName), 
            new UrlString(command.ImageUrl));

        if (!product.IsValid)
            return new Result(false, "Can not save this Product.", 
                product.Notifications.ToList());

        _repository.PostProduct(product);
        
        return new Result(true, "Product was successfully created.", product);
    }
}
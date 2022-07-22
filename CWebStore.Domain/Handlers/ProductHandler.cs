namespace CWebStore.Domain.Handlers;

public class ProductHandler : Notifiable<Notification>, IHandler<CreateProductCommand>
{
    private readonly IProductRepository _repository;

    public ProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public ICommandResult Handle(CreateProductCommand command)
    {
        command.Validate();
        if(!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, "Can not save this Product.", 
                command.Notifications);
        }
        
        if (_repository.ProductExists(command.ProductName))
            AddNotification("ProductHandler.Handle", "This Product already exists.");

        var product = new Product(new ProductName(command.ProductName), new Price(command.SellValue), 
            new Quantity(command.StockQuantity), new Description(command.ProductDescription), 
            new Manufacturer(command.ManufacturerName), new FileName(command.ImageFileName), 
            new UrlString(command.ImageUrl));

        if (!product.IsValid)
            return new CommandResult(false, "Can not save this Product.", product.Notifications);

        _repository.PostProduct(product);
        
        return new CommandResult(true, "Product successfully saved.");
    }
}
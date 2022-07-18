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
            return new CommandResult(false, "Can not save this Product.", command.Notifications.ToList());
        }
        
        if (_repository.ProductExists(command.ProductName))
            AddNotification("ProductHandler.Handle", "This Product has already been added.");

        var product = new Product(new ProductName(command.ProductName), new Price(command.SellValue), 
            new Quantity(command.StockQuantity), new Description(command.ProductDescription), 
            new Manufacturer(command.ManufacturerName), new FileName(command.ImageFileName), 
            new UrlString(command.ImageUrl));
        
        _repository.PostProduct(product);
        
        return new CommandResult(true, "Product successfully saved.");
    }
}
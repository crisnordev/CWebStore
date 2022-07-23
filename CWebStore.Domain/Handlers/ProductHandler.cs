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
            return new CommandResult(false, "This is not a valid Product.", 
                new List<Notification>(command.Notifications));
        }

        if (_repository.ProductExists(command.ProductName))
            return new CommandResult(false, "This Product already exists.");

            var product = new Product(new ProductName(command.ProductName), new Price(command.SellValue), 
            new Quantity(command.StockQuantity), new Description(command.ProductDescription), 
            new Manufacturer(command.ManufacturerName), new FileName(command.ImageFileName), 
            new UrlString(command.ImageUrl));

        if (!product.IsValid)
            return new CommandResult(false, "Can not save this Product.", 
                new List<Notification>(product.Notifications));

        _repository.PostProduct(product);
        
        return new CommandResult(true, "Product successfully saved.");
    }
}
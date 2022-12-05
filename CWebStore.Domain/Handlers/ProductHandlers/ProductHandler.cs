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
        if(!command.IsValid) return new Result(false, "This is not a valid Product.", command.Notifications.ToList());
        if (_repository.ProductExists(command.Name)) return new Result(true, "This Product already exists.");

        if (command.Cost > 0 || command.Code != null || command.AvailableStock > 0 || command.UnitMeasure != null 
            || command.ImageFileName != null || command.ImageUrl != null || command.CategoryId != null
            || command.CategoryName != null)
        {

            var product = new Product(command.Id, command.Name, command.Value, command.Cost, command.Code,
                command.AvailableStock, command.UnitMeasure, command.ImageFileName, command.ImageUrl,
                command.CategoryId, command.CategoryName);
            if (!product.IsValid) return new Result(false, "Can not save this Product.", product.Notifications.ToList());
            _repository.PostProduct(product);
            return new Result(true, "Product was successfully created.", product);
        }

        else
        {
            var product = new Product(command.Id, command.Name, command.Value);
            if (!product.IsValid) return new Result(false, "Can not save this Product.", product.Notifications.ToList());
            _repository.PostProduct(product);
            return new Result(true, "Product was successfully created.", product);
        }
    }
}


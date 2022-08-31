using CWebStore.Domain.Commands.ProductCommands.Request;
using CWebStore.Domain.Commands.ProductCommands.Response;

namespace CWebStore.Domain.Handlers.ProductHandlers;

public class ProductCommandsHandler : Notifiable<Notification>, 
    ICommandHandler<CreateProductRequestCommand>,
    ICommandHandler<DeleteProductRequestCommand>,
    ICommandHandler<UpdateProductRequestCommand>
{
    private readonly IProductRepository _repository;

    public ProductCommandsHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public IResult Handle(CreateProductRequestCommand command) =>
        new CreateProductResponseCommand(_repository, command);

    public IResult Handle(UpdateProductRequestCommand command) =>
        new UpdateProductResponseCommand(_repository, command);

    public IResult Handle(DeleteProductRequestCommand command) =>
        new DeleteProductResponseCommand(_repository, command);
}
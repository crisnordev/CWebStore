using CWebStore.Domain.Commands.CategoryCommands.Request;
using CWebStore.Domain.Commands.CategoryCommands.Response;

namespace CWebStore.Domain.Handlers.CategoryHandlers;

public class CategoryCommandsHandler : Notifiable<Notification>, 
    ICommandHandler<CreateCategoryRequestCommand>,
    ICommandHandler<UpdateCategoryRequestCommand>,
    ICommandHandler<DeleteCategoryRequestCommand>
{
    private readonly ICategoryRepository _repository;

    public CategoryCommandsHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public IResult Handle(CreateCategoryRequestCommand command) =>
        new CreateCategoryResponseCommand(_repository, command);

    public IResult Handle(UpdateCategoryRequestCommand command) =>
        new UpdateCategoryResponseCommand(_repository, command);
    
    public IResult Handle(DeleteCategoryRequestCommand command) =>
        new DeleteCategoryResponseCommand(_repository, command);
}
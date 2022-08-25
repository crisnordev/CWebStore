using CWebStore.Domain.Commands.CategoryCommands.Request;
using CWebStore.Domain.Commands.CategoryCommands.Response;

namespace CWebStore.Domain.Handlers.CategoryHandlers;

public class CategoryCommandsHandler : Notifiable<Notification>, ICommandHandler<CreateCategoryRequestCommand>
{
    private readonly ICategoryRepository _repository;

    public CategoryCommandsHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }
    
    public IResult Handle(CreateCategoryRequestCommand command)
    {
        var categoryExists = _repository.CategoryExists(command.Name);
        if (categoryExists.Result)
            return new Result<CreateCategoryRequestCommand>(false, command, "This category already exists.");

        var category = new Category(new CategoryName(command.Name));
        _repository.PostCategory(category);

        return new Result<CreateCategoryResponseCommand>(true, category, "Category created.");
    }
}
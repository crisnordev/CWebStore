using CWebStore.Domain.Commands.CategoryCommands;

namespace CWebStore.Domain.Handlers.CategoryHandlers;

public class CategoryHandler : Notifiable<Notification>, IHandler<CreateCategoryCommand>
{
    private readonly ICategoryRepository _repository;

    public CategoryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }
    public IResult Handle(CreateCategoryCommand command)
    {
        command.Validate();
        if (!command.IsValid)
        {
            return new Result(false, "This is not a valid Category.", 
                command.Notifications.ToList());
        }
        
        if (_repository.CategoryExists(command.Name))
            return new Result(false, "This category already exists.");

        var category = new Category(new CategoryName(command.Name));

        if (!category.IsValid)
            return new Result(false, "Can not save this Category.", category,
                category.Notifications.ToList());
        
        _repository.PostCategory(category);
        
        return new Result(true, "Category was successfully created.", category);
    }
}
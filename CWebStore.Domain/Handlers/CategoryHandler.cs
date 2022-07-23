namespace CWebStore.Domain.Handlers;

public class CategoryHandler : Notifiable<Notification>, IHandler<CreateCategoryCommand>
{
    private readonly ICategoryRepository _repository;

    public CategoryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }
    public ICommandResult Handle(CreateCategoryCommand command)
    {
        command.Validate();
        if (!command.IsValid)
        {
            return new CommandResult(false, "This is not a valid Category.", 
                new List<Notification>(command.Notifications));
        }
        
        if (_repository.CategoryExists(command.Name))
            return new CommandResult(false, "This category already exists.");

        var category = new Category(new CategoryName(command.Name));

        if (!category.IsValid)
            return new CommandResult(false, "Can not save this Category.", 
                new List<Notification>(category.Notifications));
        
        _repository.PostCategory(category);
        
        return new CommandResult(true, "Category successfully saved.", new
        {
            category.Id,
            category.CategoryName.Name
        });
    }
}
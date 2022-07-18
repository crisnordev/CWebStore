namespace CWebStore.Domain.Handlers;

public class CategoryHandler : Notifiable<Notification>, IHandler<CreateCategoryCommand>
{
    public ICommandResult Handle(CreateCategoryCommand command)
    {
        throw new NotImplementedException();
    }
}
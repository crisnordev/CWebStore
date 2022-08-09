namespace CWebStore.Domain.Commands.CategoryCommands;

public class CreateCategoryCommand : Notifiable<Notification>, ICommand
{
    public CreateCategoryCommand() { }

    public CreateCategoryCommand(string name)
    {
        Name = name;
        Validate();
    }

    public string Name { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<string>()
            .IsNotNullOrEmpty(Name, "CreateCategoryCommand.Name",
                "Category name must not be null or empty.")
            .IsLowerThan(2, Name.Length, "CreateCategoryCommand.Name",
                "Category name must have two or more characters.")
            .IsGreaterOrEqualsThan(80, Name.Length, "CreateCategoryCommand.Name",
                "Category name must have 80 or less characters."));
    }
}
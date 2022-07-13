namespace CWebStore.Domain.Commands;

public class CreateCategoryCommand : Notifiable<Notification>, ICommand
{
    public string Name { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .IsNotNullOrEmpty(Name, "CategoryName.Name",
                "Category name must not be null or empty.")
            .IsLowerThan(2, Name.Length, "CategoryName.Name",
                "Category name must have two or more characters.")
            .IsGreaterOrEqualsThan(80, Name.Length, "CategoryName.Name",
                "Category name must have 80 or less characters."));
    }
}
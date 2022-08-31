namespace CWebStore.Domain.ViewModels.CategoryViewModels;

public class CategoryViewModel: Notifiable<Notification>
{
    public CategoryViewModel() { }

    public CategoryViewModel(Guid id)
    {
        Id = id;
    }

    public CategoryViewModel(string name)
    {
        Name = name;
    }

    public CategoryViewModel(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; set; }

    public string Name { get; set; }

    public static implicit operator CategoryViewModel(Category category) => new(category.CategoryName.Name);
}
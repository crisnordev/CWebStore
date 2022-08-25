namespace CWebStore.Domain.ViewModels.CategoryViewModels;

public class CategoryViewModel
{
    public CategoryViewModel() { }

    public CategoryViewModel(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; set; }

    public string Name { get; set; }

    public static implicit operator CategoryViewModel(Category category) => new()
    {
        Id = category.Id,
        Name = category.CategoryName.Name
    };
}
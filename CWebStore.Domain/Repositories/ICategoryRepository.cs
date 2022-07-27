namespace CWebStore.Domain.Repositories.Interfaces;

public interface ICategoryRepository
{
    bool CategoryExists(string categoryName);

    void PostCategory(Category category);

    void UpdateCategory(Category category);

    void DeleteCategory(Guid id);
}
namespace CWebStore.Domain.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<bool> CategoryExists(string categoryName);

    Task<Category> GetCategoryById(Guid id);

    Task<Category> PostCategory(Category category);

    void UpdateCategory(Category category);

    void DeleteCategory(Category category);
}
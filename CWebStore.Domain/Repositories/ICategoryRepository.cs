namespace CWebStore.Domain.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<bool> CategoryExists(string categoryName);

    Task<IEnumerable<Category>> GetAllCategories();

    Task<Category> GetCategoryById(Guid id);

    Task<Category> PostCategory(Category category);

    Task<Category> UpdateCategory(Category category);

    Task<Category> DeleteCategory(Category category);
}
namespace CWebStore.Domain.Repositories.Interfaces;

public interface ICategoryRepository
{
    void CategoryExists(string categoryName);
    
    void GetCategory(Guid id);

    void PostCategory(Category category);

    void UpdateCategory(Category category);

    void DeleteCategory(Guid id);
}
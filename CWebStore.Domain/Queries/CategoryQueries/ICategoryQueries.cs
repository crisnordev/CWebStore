namespace CWebStore.Domain.Queries.CategoryQueries.Interfaces;

public interface ICategoryQueries
{
    Task<List<Category>> GetCategories();

    Task<Category> GetCategoryById(Guid id);
    
    Task<Category> GetCategoryByName(string name);
    
    Task<Category> GetCategoryProducts(Guid id);
}
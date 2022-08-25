namespace CWebStore.Domain.Queries.CategoryQueries.Interfaces;

public interface ICategoryQueries
{
    Task<IEnumerable<Product>> GetCategoryProducts();
}
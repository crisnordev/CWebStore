namespace CWebStore.Domain.Queries.ProductQueries.Interfaces;

public interface IProductQueries
{
    Task<List<Product>> GetProducts();

    Task<Product> GetProductById(Guid id);
    
    Task<Product> GetProductByName(string name);
    
    Task<List<Product>> GetProductsInStock();
    
    Task<List<Product>> GetProductsOutStock();
}
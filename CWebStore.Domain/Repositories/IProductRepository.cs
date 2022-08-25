namespace CWebStore.Domain.Repositories.Interfaces;

public interface IProductRepository
{
    Task<bool> ProductExists(string productName);

    Task<IEnumerable<Product>> GetAllProducts();

    Task<Product> GetProductById(Guid id);

    Task<Product> PostProduct(Product product);

    Task<Product> UpdateProduct(Product product);

    Task<Product> DeleteProduct(Product product);
}
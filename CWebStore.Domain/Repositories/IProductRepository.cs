namespace CWebStore.Domain.Repositories.Interfaces;

public interface IProductRepository
{
    Task<bool> ProductExists(string productName);

    Task<Product> GetProductById(Guid id);

    Task<Product> PostProduct(Product product);

    void UpdateProduct(Product product);

    void DeleteProduct(Product product);
}
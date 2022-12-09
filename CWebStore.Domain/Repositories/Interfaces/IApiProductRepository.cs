namespace CWebStore.Domain.Repositories.Interfaces;

public interface IApiProductRepository
{
    bool ProductExists(string productName);

    IList<Product> GetAllProducts();

    Product GetProductByName(string name);
    
    Product GetProductById(Guid id);
}
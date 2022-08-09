namespace CWebStore.Domain.Repositories.Interfaces;

public interface IProductRepository
{
    bool ProductExists(string productName);

    IList<Product> GetAllProducts();

    Product GetProductById(Guid id);

    IResult PostProduct(Product product);

    IResult UpdateProduct(Product product);

    IResult DeleteProduct(Guid id);
}
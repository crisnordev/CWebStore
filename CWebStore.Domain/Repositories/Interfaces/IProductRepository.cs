namespace CWebStore.Domain.Repositories.Interfaces;

public interface IProductRepository
{
    bool ProductExists(string productName);

    void PostProduct(Product product);

    void UpdateProduct(Product product);

    void DeleteProduct(Guid id);

    void AddCategory(Category category);
}
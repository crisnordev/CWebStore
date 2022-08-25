using CWebStore.Domain.Repositories.Interfaces;

namespace CWebStore.Tests.Mocks;

public class FakeProductRepository : IProductRepository
{
    private readonly FakeProductCategory _fakeProductCategory;

    public FakeProductRepository()
    {
        _fakeProductCategory = new FakeProductCategory();
    }

    public async Task<bool> ProductExists(string productName) =>
        _fakeProductCategory.Products.Select(x => x.ProductName.Name).All(x => x != productName);

    public async Task<IEnumerable<Product>> GetAllProducts() => _fakeProductCategory.Products;

    public async Task<Product> GetProductById(Guid id) => _fakeProductCategory.Products.First(x => x.Id == id);

    public async Task<Product> PostProduct(Product product) => product;

    public async Task<Product> UpdateProduct(Product product) => product;

    public async Task<Product> DeleteProduct(Product product) => product;
}
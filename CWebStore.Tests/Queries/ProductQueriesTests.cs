using CWebStore.Domain.Queries;
using CWebStore.Tests.Mocks;

namespace CWebStore.Tests.Queries;

[TestClass]
public class ProductQueriesTests
{
    private readonly List<Product> _products;

    public ProductQueriesTests()
    {
        var fakeProduct = new FakeProduct();

        _products = new List<Product>();
        _products.AddRange(fakeProduct.Products);
    } 
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Queries")]
    public void Given_query_GetProductsInStock_should_not_return_products_with_same_name_as_test()
    {
        var query = ProductQueries.GetProductsInStock();
        var products = _products.AsQueryable().Where(query).ToList();
        Assert.IsFalse(products.Any(x => x.ProductName.Name == "Out product name"));
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Queries")]
    public void Given_query_GetProductsOutOfStock_should_not_return_products_with_same_name_as_test()
    {
        var query = ProductQueries.GetProductsOutOfStock();
        var products = _products.AsQueryable().Where(query).ToList();
        Assert.IsFalse(products.Any(x => x.ProductName.Name == "First product"));
    }

    [TestMethod]
    [TestCategory("CWebStore.Domain.Queries")]
    public void Given_query_GetProductsInStock_should_return_products_count_equals_3()
    {
        var query = ProductQueries.GetProductsInStock();
        var products = _products.AsQueryable().Where(query).ToList();
        Assert.AreEqual(3, products.Count);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Queries")]
    public void Given_query_GetProductsOutOfStock_should_return_products_count_equals_1()
    {
        var query = ProductQueries.GetProductsInStock();
        var products = _products.AsQueryable().Where(query).ToList();
        Assert.AreEqual(3, products.Count);
    }
}
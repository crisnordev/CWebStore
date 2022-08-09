using CWebStore.Domain.Queries;
using CWebStore.Tests.Mocks;

namespace CWebStore.Tests.Queries;

[TestClass]
public class CategoryQueriesTests
{
    private readonly Category _category;
    
    private readonly List<Category> _categories;
    
    private readonly List<Product> _products;
    
    public CategoryQueriesTests()
    {
        var fakeProduct = new FakeProduct();
        
        _category = fakeProduct.Category;
        _products = new List<Product>();
        _products.AddRange(fakeProduct.Products);
        _categories = new List<Category>();
        _categories.AddRange(fakeProduct.Categories);
    } 
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Queries")]
    public void Given_a_category_guid_with_no_products_GetCategoryProducts_should_return_empty_category_products()
    {
        var category = _categories.FirstOrDefault(x => x.CategoryName.Name == "Name");
        var query = CategoryQueries.GetCategoryProducts(category.Id);
        var categoryProducts = _products.AsQueryable().Where(query).ToList();
        Assert.IsFalse(categoryProducts.Any(x => x.Categories.Any(y => y.Id == _category.Id)));
    }

    [TestMethod]
    [TestCategory("CWebStore.Domain.Queries")]
    public void Given_a_guid_GetCategoryProducts_should_return_populated_category_products()
    {
        var query = CategoryQueries.GetCategoryProducts(_category.Id);
        var categoryProducts = _products.AsQueryable().Where(query).ToList();
        Assert.IsTrue(categoryProducts.All(x => x.Categories.Any(y => y.Id == _category.Id)));
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Queries")]
    public void Given_a_guid_GetCategoryProducts_should_return_same_category_products_as_test()
    {
        var query = CategoryQueries.GetCategoryProducts(_category.Id);
        var categoryProducts = _products.AsQueryable().Where(query).ToList();
        var category = categoryProducts.First().Categories.FirstOrDefault(x => x.Id == _category.Id);
        Assert.AreEqual("Category", category.CategoryName.Name);
        
        var category1 = categoryProducts.Last().Categories.FirstOrDefault(x => x.Id == _category.Id);
        Assert.AreEqual("Category", category1.CategoryName.Name);
    }
}
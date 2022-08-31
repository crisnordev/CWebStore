using CWebStore.Domain.Repositories.Interfaces;

namespace CWebStore.Tests.Mocks;

public class FakeCategoryRepository : ICategoryRepository
{
    private readonly FakeProductCategory _fakeProductCategory;

    public FakeCategoryRepository()
    {
        _fakeProductCategory = new FakeProductCategory();
    }

    public async Task<bool> CategoryExists(Guid id)=> 
        _fakeProductCategory.Categories.Select(x => x.Id).All(x => x != id);

    public async Task<bool> CategoryExists(string categoryName) => 
        _fakeProductCategory.Categories.Select(x => x.CategoryName.Name).All(x => x != categoryName);

    public async Task<IEnumerable<Category>> GetAllCategories() => _fakeProductCategory.Categories;

    public async Task<Category> GetCategoryById(Guid id) => _fakeProductCategory.Categories.First(x => x.Id == id);

    public async Task<Category> PostCategory(Category category) => category;

    public void UpdateCategory(Category category) {}

    public void DeleteCategory(Category category) {}
}
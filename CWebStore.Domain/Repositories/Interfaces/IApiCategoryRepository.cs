namespace CWebStore.Domain.Repositories.Interfaces;

public interface IApiCategoryRepository
{
    bool CategoryExists(string categoryName);

    IList<Category> GetAllCategories();

    Category GetCategoryById(Guid id);

    IResult PostCategory(Category category);

    IResult UpdateCategory(Category category);

    IResult DeleteCategory(Guid id);
}
using System.Linq.Expressions;

namespace CWebStore.Domain.Queries;

public static class CategoryQueries
{
    public static Expression<Func<Product, bool>> GetCategoryProducts(Guid categoryId)
    {
        return x => x.Categories.Any(y => y.Id == categoryId);
    }
}
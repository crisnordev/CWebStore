using System.Linq.Expressions;

namespace CWebStore.Domain.Queries;

public static class CategoryQueries
{
    public static Expression<Func<IList<Product>, bool>> GetCategoryProducts(Guid categoryId)
    {
        return x => x.All(prod => prod.Categories.Any(cat => cat.Id == categoryId));
    }
}
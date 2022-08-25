using CWebStore.Domain.Queries.CategoryQueries.Interfaces;
using CWebStore.Domain.Queries.CategoryQueries.Request;
using CWebStore.Domain.Queries.CategoryQueries.Response;

namespace CWebStore.Domain.Handlers.CategoryHandlers;

public class CategoryQueriesHandler : Notifiable<Notification>, IQueryHandler<GetCategoryProductsRequest>
{
    private readonly ICategoryQueries _categoryQueries;

    public CategoryQueriesHandler(ICategoryQueries categoryQueries)
    {
        _categoryQueries = categoryQueries;
    }

    public IResult Handle(GetCategoryProductsRequest query)
    {
        var products = _categoryQueries.GetCategoryProducts();
        return new Result<GetCategoryProductsResponseQuery>(true, products.Result.ToList(), 
            "Category products list created.");
    }
}
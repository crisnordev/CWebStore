using CWebStore.Domain.Queries.CategoryQueries.Interfaces;
using CWebStore.Domain.Queries.CategoryQueries.Request;
using CWebStore.Domain.Queries.CategoryQueries.Response;

namespace CWebStore.Domain.Handlers.CategoryHandlers;

public class CategoryQueriesHandler : Notifiable<Notification>, 
    IQueryHandler<GetCategoriesRequest>,
    IQueryHandler<GetCategoryByIdRequest>,
    IQueryHandler<GetCategoryByNameRequest>,
    IQueryHandler<GetCategoryProductsRequest>
{
    private readonly ICategoryQueries _categoryQueries;

    public CategoryQueriesHandler(ICategoryQueries categoryQueries)
    {
        _categoryQueries = categoryQueries;
    }

    public IResult Handle(GetCategoryProductsRequest query) => 
        new GetCategoryProductsResponse(_categoryQueries, query.CategoryId);

    public IResult Handle(GetCategoriesRequest query) =>
        new GetCategoriesResponse(_categoryQueries);

    public IResult Handle(GetCategoryByIdRequest query) =>
        new GetCategoryByIdResponse(_categoryQueries, query.CategoryId);
    
    public IResult Handle(GetCategoryByNameRequest query) =>
        new GetCategoryByNameResponse(_categoryQueries, query.CategoryName);
}
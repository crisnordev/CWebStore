using CWebStore.Domain.Queries.CategoryQueries.Interfaces;
using CWebStore.Domain.Queries.CategoryQueries.Request;
using CWebStore.Domain.Queries.CategoryQueries.Response;

namespace CWebStore.Domain.Handlers.CategoryHandlers;

public class CategoryQueriesHandler : Notifiable<Notification>, 
    IQueryHandler<GetCategoriesRequestQuery>,
    IQueryHandler<GetCategoryByIdRequestQuery>,
    IQueryHandler<GetCategoryByNameRequestQuery>,
    IQueryHandler<GetCategoryProductsRequestQuery>
{
    private readonly ICategoryQueries _categoryQueries;

    public CategoryQueriesHandler(ICategoryQueries categoryQueries)
    {
        _categoryQueries = categoryQueries;
    }

    public IResult Handle(GetCategoryProductsRequestQuery query) => 
        new GetCategoryProductsResponseQuery(_categoryQueries, query.CategoryId);

    public IResult Handle(GetCategoriesRequestQuery query) =>
        new GetCategoriesResponseQuery(_categoryQueries);

    public IResult Handle(GetCategoryByIdRequestQuery query) =>
        new GetCategoryByIdResponseQuery(_categoryQueries, query.CategoryId);
    
    public IResult Handle(GetCategoryByNameRequestQuery query) =>
        new GetCategoryByNameResponseQuery(_categoryQueries, query.CategoryName);
}
using CWebStore.Domain.Queries.ProductQueries.Interfaces;
using CWebStore.Domain.Queries.ProductQueries.Request;
using CWebStore.Domain.Queries.ProductQueries.Response;

namespace CWebStore.Domain.Handlers.ProductHandlers;

public class ProductQueriesHandler : Notifiable<Notification>, 
    IQueryHandler<GetProductsRequestQuery>,
    IQueryHandler<GetProductByIdRequestQuery>,
    IQueryHandler<GetProductByNameRequestQuery>,
    IQueryHandler<GetProductsInStockRequestQuery>,
    IQueryHandler<GetProductsOutOfStockRequestQuery>
{
    private readonly IProductQueries _productQueries;

    public ProductQueriesHandler(IProductQueries productQueries)
    {
        _productQueries = productQueries;
    }

    public IResult Handle(GetProductsRequestQuery query) =>
        new GetProductsResponseQuery(_productQueries);

    public IResult Handle(GetProductByIdRequestQuery query) =>
        new GetProductByIdResponseQuery(_productQueries, query.ProductId);

    public IResult Handle(GetProductByNameRequestQuery query) =>
        new GetProductByNameResponseQuery(_productQueries, query.ProductName);

    public IResult Handle(GetProductsInStockRequestQuery query) =>
        new GetProductsInStockResponseQuery(_productQueries);

    public IResult Handle(GetProductsOutOfStockRequestQuery query) =>
        new GetProductsOutOfStockResponseQuery(_productQueries);
}
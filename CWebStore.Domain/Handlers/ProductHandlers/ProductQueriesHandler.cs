using CWebStore.Domain.Queries.ProductQueries.Interfaces;
using CWebStore.Domain.Queries.ProductQueries.Request;
using CWebStore.Domain.Queries.ProductQueries.Response;

namespace CWebStore.Domain.Handlers.ProductHandlers;

public class ProductQueriesHandler : Notifiable<Notification>, 
    IQueryHandler<GetProductsRequest>,
    IQueryHandler<GetProductByIdRequest>,
    IQueryHandler<GetProductByNameRequest>,
    IQueryHandler<GetProductsInStockRequest>,
    IQueryHandler<GetProductsOutOfStockRequest>
{
    private readonly IProductQueries _productQueries;

    public ProductQueriesHandler(IProductQueries productQueries)
    {
        _productQueries = productQueries;
    }

    public IResult Handle(GetProductsRequest query) =>
        new GetProductsResponse(_productQueries);

    public IResult Handle(GetProductByIdRequest query) =>
        new GetProductByIdResponse(_productQueries, query.ProductId);

    public IResult Handle(GetProductByNameRequest query) =>
        new GetProductByNameResponse(_productQueries, query.ProductName);

    public IResult Handle(GetProductsInStockRequest query) =>
        new GetProductsInStockResponse(_productQueries);

    public IResult Handle(GetProductsOutOfStockRequest query) =>
        new GetProductsOutOfStockResponse(_productQueries);
}
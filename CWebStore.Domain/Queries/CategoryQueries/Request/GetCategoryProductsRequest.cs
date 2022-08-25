using System.Linq.Expressions;

namespace CWebStore.Domain.Queries.CategoryQueries.Request;

public class GetCategoryProductsRequest : IQuery
{
    public GetCategoryProductsRequest() { }

    public GetCategoryProductsRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
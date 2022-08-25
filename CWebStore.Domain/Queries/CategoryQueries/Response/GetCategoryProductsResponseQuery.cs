using CWebStore.Domain.ViewModels.ProductViewModels;

namespace CWebStore.Domain.Queries.CategoryQueries.Response;

public class GetCategoryProductsResponseQuery : IResult
{
    public GetCategoryProductsResponseQuery()
    {
        Products = new List<ProductViewModel>();
    }

    public GetCategoryProductsResponseQuery(List<Product> products)
    {
        Products = new List<ProductViewModel>();
        foreach (var product in products)
            Products.ToList().Add(product);
    }

    public IEnumerable<ProductViewModel> Products { get; set; }

    public static implicit operator GetCategoryProductsResponseQuery(List<Product> products) => new (products);
}
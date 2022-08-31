using CWebStore.Domain.Queries.ProductQueries.Interfaces;
using CWebStore.Domain.ViewModels.ProductViewModels;

namespace CWebStore.Domain.Queries.ProductQueries.Response;

public class GetProductsResponseQuery : Result
{
    public GetProductsResponseQuery()
    {
        Products = new List<ProductViewModel>();
    }

    public GetProductsResponseQuery(IProductQueries productQueries)
    {
        Products = new List<ProductViewModel>();
        var products = productQueries.GetProducts().Result;
        Validate(products);
        if (!IsValid) return;
        
        foreach (var product in products)
            Products.Add(product );
        Success = true;
        Message = "Products list Created.";
    }

    public IList<ProductViewModel> Products { get; set; }

    public void Validate(IEnumerable<Product> products) => AddNotifications(new Contract<GetProductsResponseQuery>()
        .AreEquals(0, products.Count(), "GetProductsResponseQuery.Products",
            "Can not find any product."));
}
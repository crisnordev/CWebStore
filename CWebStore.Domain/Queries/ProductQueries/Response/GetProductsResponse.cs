using CWebStore.Domain.Queries.ProductQueries.Interfaces;
using CWebStore.Domain.ViewModels.ProductViewModels;

namespace CWebStore.Domain.Queries.ProductQueries.Response;

public class GetProductsResponse : Result
{
    private readonly IProductQueries _productQueries;
    public GetProductsResponse()
    {
        Products = new List<ProductViewModel>();
    }

    public GetProductsResponse(IProductQueries productQueries)
    {
        _productQueries = productQueries;
        
        Products = new List<ProductViewModel>();
        var products = _productQueries.GetProducts().Result;
        Validate(products);
        if (!IsValid) return;
        
        foreach (var product in products)
            Products.Add(product );
        Success = true;
        Message = "Products list Created.";
    }

    public IList<ProductViewModel> Products { get; set; }

    public void Validate(IEnumerable<Product> products) => AddNotifications(new Contract<GetProductsResponse>()
        .AreEquals(0, products.Count(), "GetProductsResponseQuery.Products",
            "Can not find any product."));
}
using System.ComponentModel.DataAnnotations;
using CWebStore.Domain.Queries.ProductQueries.Interfaces;
using CWebStore.Domain.ViewModels.ProductViewModels;

namespace CWebStore.Domain.Queries.ProductQueries.Response;

public class GetProductsInStockResponse : Result, IValidatable
{
    private readonly IProductQueries _productQueries;
    
    public GetProductsInStockResponse()
    {
        Products = new List<ProductViewModel>();
    }

    public GetProductsInStockResponse(IProductQueries productQueries)
    {
        _productQueries = productQueries;
        
        Products = new List<ProductViewModel>();
        var products = _productQueries.GetProductsOutStock().Result;
        Validate(products);
        if (!IsValid) return;

        foreach (var product in products)
            Products.Add(product);
        Success = true;
        Message = "Products in stock list created.";
    }

    public IList<ProductViewModel> Products { get; set; }
    
    public void Validate(IEnumerable<Product> products) => 
        AddNotifications(new Contract<GetProductsInStockResponse>()
        .IsLowerOrEqualsThan(0, products.Count(), "GetProductsInStockResponseQuery.Products",
            "Products must have stock quantity greater 0."));
}
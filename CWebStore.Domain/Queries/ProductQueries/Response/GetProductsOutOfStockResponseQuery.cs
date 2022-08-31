using System.ComponentModel.DataAnnotations;
using CWebStore.Domain.Queries.ProductQueries.Interfaces;
using CWebStore.Domain.ViewModels.ProductViewModels;

namespace CWebStore.Domain.Queries.ProductQueries.Response;

public class GetProductsOutOfStockResponseQuery : Result, IValidatable
{
    public GetProductsOutOfStockResponseQuery()
    {
        Products = new List<ProductViewModel>();
    }
    
    public GetProductsOutOfStockResponseQuery(IProductQueries productQueries)
    {
        Products = new List<ProductViewModel>();
        var products = productQueries.GetProductsOutStock().Result;
        Validate(products);
        if (!IsValid) return;
        
        foreach (var product in products)
            Products.Add(product);
        Success = true;
        Message = "Products out stock list created.";
    }

    public IList<ProductViewModel> Products { get; set; }

    public void Validate(IEnumerable<Product> products) => 
        AddNotifications(new Contract<GetProductsOutOfStockResponseQuery>()
            .IsGreaterThan(0, products.Count(), "GetProductsOutOfStockResponseQuery.Products",
                "Products must have stock quantity lower or equals 0."));
}
using System.ComponentModel.DataAnnotations;
using CWebStore.Domain.Queries.ProductQueries.Interfaces;
using CWebStore.Domain.ViewModels.ProductViewModels;

namespace CWebStore.Domain.Queries.ProductQueries.Response;

public class GetProductsInStockResponseQuery : Result, IValidatable
{
    public GetProductsInStockResponseQuery()
    {
        Products = new List<ProductViewModel>();
    }

    public GetProductsInStockResponseQuery(IProductQueries productQueries)
    {
        Products = new List<ProductViewModel>();
        var products = productQueries.GetProductsOutStock().Result;
        Validate(products);
        if (!IsValid) return;

        foreach (var product in products)
            Products.Add(product);
        Success = true;
        Message = "Products in stock list created.";
    }

    public IList<ProductViewModel> Products { get; set; }
    
    public void Validate(IEnumerable<Product> products) => 
        AddNotifications(new Contract<GetProductsInStockResponseQuery>()
        .IsLowerOrEqualsThan(0, products.Count(), "GetProductsInStockResponseQuery.Products",
            "Products must have stock quantity greater 0."));
}
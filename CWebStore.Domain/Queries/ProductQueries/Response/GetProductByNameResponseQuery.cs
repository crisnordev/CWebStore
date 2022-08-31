using System.ComponentModel.DataAnnotations;
using CWebStore.Domain.Queries.ProductQueries.Interfaces;
using CWebStore.Domain.ViewModels.ProductViewModels;

namespace CWebStore.Domain.Queries.ProductQueries.Response;

public class GetProductByNameResponseQuery : Result
{
    public GetProductByNameResponseQuery()
    {
    }

    public GetProductByNameResponseQuery(IProductQueries productQueries, string name)
    {
        Product = productQueries.GetProductByName(name).Result;
        Validate();
        if (!IsValid) return;

        Success = true;
        Message = "Product found.";
    }

    public ProductViewModel Product { get; set; }

    public void Validate() =>
        AddNotifications(new Contract<GetProductByNameResponseQuery>()
            .IsNotNullOrEmpty(Product.Name, "GetProductByNameResponseQuery.Products"
                , "Can not find product."));
}
using System.ComponentModel.DataAnnotations;
using CWebStore.Domain.Queries.ProductQueries.Interfaces;
using CWebStore.Domain.ViewModels.ProductViewModels;

namespace CWebStore.Domain.Queries.ProductQueries.Response;

public class GetProductByNameResponse : Result
{
    private readonly IProductQueries _productQueries;
    
    public GetProductByNameResponse(){ }

    public GetProductByNameResponse(IProductQueries productQueries, string name)
    {
        _productQueries = productQueries;
        
        Product = _productQueries.GetProductByName(name).Result;
        Validate();
        if (!IsValid) return;

        Success = true;
        Message = "Product found.";
    }

    public ProductViewModel Product { get; set; }

    public void Validate() =>
        AddNotifications(new Contract<GetProductByNameResponse>()
            .IsNotNullOrEmpty(Product.Name, "GetProductByNameResponseQuery.Products"
                , "Can not find product."));
}
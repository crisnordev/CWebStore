using CWebStore.Domain.Queries.ProductQueries.Interfaces;
using CWebStore.Domain.ViewModels.ProductViewModels;

namespace CWebStore.Domain.Queries.ProductQueries.Response;

public class GetProductByIdResponse : Result
{
    private readonly IProductQueries _productQueries;
    
    public GetProductByIdResponse() { }

    public GetProductByIdResponse(IProductQueries productQueries, Guid id)
    {
        _productQueries = productQueries;
        
        Product = _productQueries.GetProductById(id).Result;
        Validate();
        if (!IsValid) 
            Success = false;
        
        Success = true;
        Message = "Product found.";

    }
    
    public ProductViewModel Product { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<GetProductByIdResponse>()
            .IsNotNullOrEmpty(Product.Name, "GetProductByIdResponseQuery.Products"
                , "Can not find Product."));
    }
}
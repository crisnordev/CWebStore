using System.ComponentModel.DataAnnotations;
using CWebStore.Domain.Queries.ProductQueries.Interfaces;
using CWebStore.Domain.ViewModels.ProductViewModels;

namespace CWebStore.Domain.Queries.ProductQueries.Response;

public class GetProductByIdResponseQuery : Result
{
    public GetProductByIdResponseQuery() { }

    public GetProductByIdResponseQuery(IProductQueries productQueries, Guid id)
    {
        Product = productQueries.GetProductById(id).Result;
        Validate();
        if (!IsValid) 
            Success = false;
        
        Success = true;
        Message = "Product found.";

    }
    
    public ProductViewModel Product { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<GetProductByIdResponseQuery>()
            .IsNotNullOrEmpty(Product.Name, "GetProductByIdResponseQuery.Products"
                , "Can not find Product."));
    }
}
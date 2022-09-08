using System.ComponentModel.DataAnnotations;
using CWebStore.Domain.Queries.CategoryQueries.Interfaces;
using CWebStore.Domain.ViewModels.ProductViewModels;

namespace CWebStore.Domain.Queries.CategoryQueries.Response;

public class GetCategoryProductsResponse : Result
{
    private readonly ICategoryQueries _categoryQueries;
    
    public GetCategoryProductsResponse()
    {
        Products = new List<ProductViewModel>();
    }

    public GetCategoryProductsResponse(ICategoryQueries categoryQueries, Guid id)
    {
        _categoryQueries = categoryQueries;
        
        Products = new List<ProductViewModel>();
        var category = _categoryQueries.GetCategoryProducts(id).Result;
        Validate(category.CategoryName.ToString());
        if (!IsValid) return;
        
        CategoryName = category.CategoryName.ToString();
        
        Validate(category.Products);
        if (!IsValid) return;
        
        foreach (var product in category.Products)
            Products.ToList().Add(product);
        Success = true;
        Message = "Category products list created.";
    }
    
    [Display(Name = "Category name")] public string CategoryName { get; set; }

    [Display(Name = "Products")] public IEnumerable<ProductViewModel> Products { get; set; }
    
    public void Validate(string name) =>
        AddNotifications(new Contract<GetCategoryProductsResponse>()
            .IsNotNullOrEmpty(name, "GetCategoryProductsResponseQuery.CategoryName"
                , "Can not find category."));
    
    public void Validate(IEnumerable<Product> products) => 
        AddNotifications(new Contract<GetCategoryProductsResponse>()
        .AreEquals(0, products.Count(), "GetCategoryProductsResponseQuery.Products",
            "Can not find any product."));
}
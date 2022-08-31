using System.ComponentModel.DataAnnotations;
using CWebStore.Domain.Queries.CategoryQueries.Interfaces;
using CWebStore.Domain.ViewModels.ProductViewModels;

namespace CWebStore.Domain.Queries.CategoryQueries.Response;

public class GetCategoryProductsResponseQuery : Result
{
    public GetCategoryProductsResponseQuery()
    {
        Products = new List<ProductViewModel>();
    }

    public GetCategoryProductsResponseQuery(ICategoryQueries categoryQueries, Guid id)
    {
        Products = new List<ProductViewModel>();
        var category = categoryQueries.GetCategoryProducts(id).Result;
        Validate(category.CategoryName.Name);
        if (!IsValid) return;
        
        CategoryName = category.CategoryName.Name;
        
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
        AddNotifications(new Contract<GetCategoryProductsResponseQuery>()
            .IsNotNullOrEmpty(name, "GetCategoryProductsResponseQuery.CategoryName"
                , "Can not find category."));
    
    public void Validate(IEnumerable<Product> products) => 
        AddNotifications(new Contract<GetCategoryProductsResponseQuery>()
        .AreEquals(0, products.Count(), "GetCategoryProductsResponseQuery.Products",
            "Can not find any product."));
}
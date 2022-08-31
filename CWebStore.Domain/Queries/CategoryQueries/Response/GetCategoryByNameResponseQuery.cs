using System.ComponentModel.DataAnnotations;
using CWebStore.Domain.Queries.CategoryQueries.Interfaces;
using CWebStore.Domain.ViewModels.CategoryViewModels;

namespace CWebStore.Domain.Queries.CategoryQueries.Response;

public class GetCategoryByNameResponseQuery : Result
{
    public GetCategoryByNameResponseQuery() { }

    public GetCategoryByNameResponseQuery(ICategoryQueries categoryQueries, string name)
    {
        Category = categoryQueries.GetCategoryByName(name).Result;
        Validate();
        if (!IsValid) return;
        
        Success = true;
        Message = "Category found.";
    }

    public CategoryViewModel Category { get; set; }
    
    public void Validate() =>
        AddNotifications(new Contract<GetCategoryByNameResponseQuery>()
            .IsNotNullOrEmpty(Category.Name, "GetCategoryByNameResponseQuery.Category"
                , "Can not find category."));
}
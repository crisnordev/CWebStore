using System.ComponentModel.DataAnnotations;
using CWebStore.Domain.Queries.CategoryQueries.Interfaces;
using CWebStore.Domain.ViewModels.CategoryViewModels;

namespace CWebStore.Domain.Queries.CategoryQueries.Response;

public class GetCategoryByIdResponseQuery : Result
{
    public GetCategoryByIdResponseQuery() { }
    
    public GetCategoryByIdResponseQuery(ICategoryQueries categoryQueries, Guid id)
    {
        Category = categoryQueries.GetCategoryById(id).Result;
        Validate();
        if (!IsValid) return;
        
        Success = true;
        Message = "Category found.";
    }

    public CategoryViewModel Category { get; set; }
    
    public void Validate() =>
        AddNotifications(new Contract<GetCategoryByIdResponseQuery>()
            .IsNotNullOrEmpty(Category.Name, "GetCategoryByIdResponseQuery.Category"
                , "Can not find category."));
}
using CWebStore.Domain.Queries.CategoryQueries.Interfaces;
using CWebStore.Domain.ViewModels.CategoryViewModels;

namespace CWebStore.Domain.Queries.CategoryQueries.Response;

public class GetCategoryByNameResponse : Result
{
    private readonly ICategoryQueries _categoryQueries;
    
    public GetCategoryByNameResponse() { }

    public GetCategoryByNameResponse(ICategoryQueries categoryQueries, string name)
    {
        _categoryQueries = categoryQueries;
        
        Category = _categoryQueries.GetCategoryByName(name).Result;
        Validate();
        if (!IsValid) return;
        
        Success = true;
        Message = "Category found.";
    }

    public CategoryViewModel Category { get; set; }
    
    public void Validate() =>
        AddNotifications(new Contract<GetCategoryByNameResponse>()
            .IsNotNullOrEmpty(Category.Name, "GetCategoryByNameResponseQuery.Category"
                , "Can not find category."));
}
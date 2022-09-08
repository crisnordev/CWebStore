using CWebStore.Domain.Queries.CategoryQueries.Interfaces;
using CWebStore.Domain.ViewModels.CategoryViewModels;

namespace CWebStore.Domain.Queries.CategoryQueries.Response;

public class GetCategoryByIdResponse : Result
{
    private readonly ICategoryQueries _categoryQueries;
    
    public GetCategoryByIdResponse() { }
    
    public GetCategoryByIdResponse(ICategoryQueries categoryQueries, Guid id)
    {
        _categoryQueries = categoryQueries;
        
        Category = _categoryQueries.GetCategoryById(id).Result;
        Validate();
        if (!IsValid) return;
        
        Success = true;
        Message = "Category found.";
    }

    public CategoryViewModel Category { get; set; }
    
    public void Validate() =>
        AddNotifications(new Contract<GetCategoryByIdResponse>()
            .IsNotNullOrEmpty(Category.Name, "GetCategoryByIdResponseQuery.Category"
                , "Can not find category."));
}
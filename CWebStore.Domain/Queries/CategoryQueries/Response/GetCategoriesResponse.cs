using CWebStore.Domain.Queries.CategoryQueries.Interfaces;
using CWebStore.Domain.ViewModels.CategoryViewModels;

namespace CWebStore.Domain.Queries.CategoryQueries.Response;

public class GetCategoriesResponse : Result
{
    private readonly ICategoryQueries _categoryQueries;
    public GetCategoriesResponse()
    {
        Categories = new List<CategoryViewModel>();
    }

    public GetCategoriesResponse(ICategoryQueries categoryQueries)
    {
        _categoryQueries = categoryQueries;
        
        Categories = new List<CategoryViewModel>();
        var categories = _categoryQueries.GetCategories().Result;
        Validate(categories);
        if (!IsValid) return;
        
        foreach (var category in categories)
            Categories.Add(category);
        Success = true;
        Message = "Categories list created.";
    }

    public IList<CategoryViewModel> Categories { get; set; }
    
    public void Validate(IEnumerable<Category> categories) => AddNotifications(
        new Contract<GetCategoriesResponse>().AreEquals(0, categories.Count(), 
            "GetCategoriesResponseQuery.Categories", "Can not find any category."));
}
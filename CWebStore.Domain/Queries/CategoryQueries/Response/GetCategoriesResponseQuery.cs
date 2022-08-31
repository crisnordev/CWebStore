using CWebStore.Domain.Queries.CategoryQueries.Interfaces;
using CWebStore.Domain.ViewModels.CategoryViewModels;

namespace CWebStore.Domain.Queries.CategoryQueries.Response;

public class GetCategoriesResponseQuery : Result
{
    public GetCategoriesResponseQuery()
    {
        Categories = new List<CategoryViewModel>();
    }

    public GetCategoriesResponseQuery(ICategoryQueries categoryQueries)
    {
        Categories = new List<CategoryViewModel>();
        var categories = categoryQueries.GetCategories().Result;
        Validate(categories);
        if (!IsValid) return;
        
        foreach (var category in categories)
            Categories.Add(category);
        Success = true;
        Message = "Categories list created.";
    }

    public IList<CategoryViewModel> Categories { get; set; }
    
    public void Validate(IEnumerable<Category> categories) => AddNotifications(new Contract<GetCategoriesResponseQuery>()
        .AreEquals(0, categories.Count(), "GetCategoriesResponseQuery.Categories",
            "Can not find any category."));
}
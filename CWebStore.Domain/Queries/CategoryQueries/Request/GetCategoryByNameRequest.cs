using System.ComponentModel.DataAnnotations;

namespace CWebStore.Domain.Queries.CategoryQueries.Request;

public class GetCategoryByNameRequest : Notifiable<Notification>, IQuery
{
    public GetCategoryByNameRequest() { }

    [Display(Name = "Category name")] public string CategoryName { get; set; }
}
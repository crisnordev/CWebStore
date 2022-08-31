using System.ComponentModel.DataAnnotations;

namespace CWebStore.Domain.Queries.CategoryQueries.Request;

public class GetCategoryByNameRequestQuery : Notifiable<Notification>, IQuery
{
    public GetCategoryByNameRequestQuery() { }

    [Display(Name = "Category name")] public string CategoryName { get; set; }
}
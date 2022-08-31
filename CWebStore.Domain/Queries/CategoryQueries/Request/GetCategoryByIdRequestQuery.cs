using System.ComponentModel.DataAnnotations;

namespace CWebStore.Domain.Queries.CategoryQueries.Request;

public class GetCategoryByIdRequestQuery : Notifiable<Notification>, IQuery
{
    public GetCategoryByIdRequestQuery() { }

    [Display(Name = "Category Id")] public Guid CategoryId { get; set; }
}
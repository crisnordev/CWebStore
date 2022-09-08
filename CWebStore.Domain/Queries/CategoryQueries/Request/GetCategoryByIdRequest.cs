using System.ComponentModel.DataAnnotations;

namespace CWebStore.Domain.Queries.CategoryQueries.Request;

public class GetCategoryByIdRequest : Notifiable<Notification>, IQuery
{
    public GetCategoryByIdRequest() { }

    [Display(Name = "Category Id")] public Guid CategoryId { get; set; }
}